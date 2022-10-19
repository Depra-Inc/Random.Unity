// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using UnityEngine;

namespace Depra.Unity.Random.Tests
{
    internal static class Helper
    {
        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                Debug.Log(element);
            }
        }

        public static void PrintRandomizeResultForCollection<T>(IEnumerable<T> collection, T minInclusive,
            T maxExclusive)
        {
            Debug.Log($"minInclusive: {minInclusive}\n" +
                      $"maxExclusive: {maxExclusive}\n");

            PrintCollection(collection);
        }
    }
}