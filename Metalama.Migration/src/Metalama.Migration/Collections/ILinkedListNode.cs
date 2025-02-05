// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Collections
{
    [InternalImplement]
    public interface ILinkedListNode<out T>
    {
        T Value { get; }

        ILinkedListNode<T> Previous { get; }

        ILinkedListNode<T> Next { get; }
    }
}