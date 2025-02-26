// Copyright (c) SharpCrafters s.r.o. See the LICENSE.md file in the root directory of this repository root for details.

using Metalama.Framework.DesignTime.Rpc;
using Metalama.Framework.DesignTime.Rpc.Notifications;
using Metalama.Framework.DesignTime.VisualStudio.ServiceHub;
using Metalama.Framework.Engine.Services;
using Metalama.Framework.Services;
using Microsoft.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace Metalama.Framework.DesignTime.Services;

internal sealed class UserProcessInvalidationService : IGlobalService
{
    private readonly WorkspaceProvider _workspaceProvider;
    private readonly ServiceHubRpcService _serviceHub;

    public UserProcessInvalidationService( GlobalServiceProvider serviceProvider )
    {
        this._workspaceProvider = serviceProvider.GetRequiredService<WorkspaceProvider>();

        this._serviceHub = serviceProvider.GetRequiredService<IServiceHubRpcServiceProvider>().ServiceHub;

        this._serviceHub.EventReceived += this.OnServiceHubEventReceived;
    }

    private void OnServiceHubEventReceived( RpcEventData eventData )
    {
        if ( eventData is CompilationResultChangedEventData data )
        {
            this.OnCompilationResultChanged( data );
        }
    }

    private void OnCompilationResultChanged( CompilationResultChangedEventData data )
    {
        if ( !this._workspaceProvider.TryGetWorkspace( out var workspace ) )
        {
            // The workspace is not available yet.
            return;
        }

        var matchingProjects = workspace.CurrentSolution.Projects.Where( project => ProjectKeyFactory.FromProject( project ) == data.ProjectKey );

        foreach ( var project in matchingProjects )
        {
            _updateSourceGeneratorsAction?.Invoke( workspace, project.Id );
        }
    }

    private static readonly Action<Workspace, ProjectId>? _updateSourceGeneratorsAction = GetUpdateSourceGeneratorsAction();

    private static Action<Workspace, ProjectId>? GetUpdateSourceGeneratorsAction()
    {
        var updateSourceGeneratorsMethod = typeof(Workspace).GetMethod( "EnqueueUpdateSourceGeneratorVersion", BindingFlags.NonPublic | BindingFlags.Instance, null, [typeof(ProjectId), typeof(bool)], null );

        if ( updateSourceGeneratorsMethod == null )
        {
            return null;
        }

        // This is equivalent to the following code that calls an internal Roslyn method:
        // workspace.EnqueueUpdateSourceGeneratorVersion(projectId, forceRegeneration: false);

        var workspace = Expression.Parameter( typeof(Workspace), "workspace" );
        var projectId = Expression.Parameter( typeof(ProjectId), "projectdId" );
        var call = Expression.Call( workspace, updateSourceGeneratorsMethod, projectId, Expression.Constant( false ) );

        var lambda = Expression.Lambda<Action<Workspace, ProjectId>>( call, workspace, projectId );

        return lambda.Compile();
    }
}