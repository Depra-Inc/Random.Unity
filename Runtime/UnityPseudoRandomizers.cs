// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Domain.Randomizers;

namespace Depra.Unity.Random.Runtime
{
    public sealed class UnityPseudoRandomizers : IRandomizerCollection
    {
        public IRandomizer GetRandomizer(Type valueType)
        {
            switch (Type.GetTypeCode(valueType))
            {
                case TypeCode.Int32:
                    return new IntRandomizer();
                case TypeCode.Single:
                    return new FloatRandomizer();
                default:
                    throw new NullReferenceException();
            }
        }

        public IEnumerable<IRandomizer> GetAllRandomizers()
        {
            yield return new IntRandomizer();
            yield return new FloatRandomizer();
        }

        private class IntRandomizer : INumberRandomizer<int>
        {
            private static readonly Type VALUE_TYPE = typeof(int);
            public Type ValueType => VALUE_TYPE;

            public int Next() => Next(0, int.MaxValue);

            public int Next(int maxExclusive) => Next(0, maxExclusive);

            public int Next(int minInclusive, int maxExclusive) =>
                UnityEngine.Random.Range(minInclusive, maxExclusive);
        }

        private class FloatRandomizer : INumberRandomizer<float>
        {
            private static readonly Type VALUE_TYPE = typeof(float);
            public Type ValueType => VALUE_TYPE;

            public float Next() => Next(0f, float.MaxValue);

            public float Next(float maxExclusive) => Next(0f, maxExclusive);

            public float Next(float minInclusive, float maxExclusive) =>
                UnityEngine.Random.Range(minInclusive, maxExclusive);
        }
    }
}