// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;

namespace PostSharp.Collections
{
    public static class LinkedListExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>( IReadOnlyLinkedList<T> linkedList )
        {
            if ( linkedList == null )
            {
                yield break;
            }

            for ( var cursor = linkedList.First; cursor != null; cursor = cursor.Next )
            {
                yield return cursor.Value;
            }
        }

        public static IEnumerable<T> ToEnumerable<T>( ReadOnlyLinkedList<T> linkedList )
        {
            for ( var cursor = linkedList.First; cursor != null; cursor = cursor.Next )
            {
                yield return cursor.Value;
            }
        }
    }
}