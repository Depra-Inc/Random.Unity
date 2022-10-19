// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Linq;
using Depra.Random.Application.ServiceBuilder;
using Depra.Random.Application.Services;
using Depra.Unity.Random.Runtime;
using NUnit.Framework;

namespace Depra.Unity.Random.Tests
{
    [TestFixture(TestOf = typeof(UnityPseudoRandomizers))]
    internal class UnityPseudoRandomizersTests
    {
        private IRandomService _randomService;

        [SetUp]
        public void SetUp()
        {
            _randomService = new RandomServiceBuilder()
                .With(new UnityPseudoRandomizers())
                .Build();
        }

        [Test]
        public void WhenGettingNextInt32_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const int minValue = 0;
            const int maxValue = int.MaxValue;
            var randomNumbers = new int[samplesCount];
            var randomizer = _randomService.GetTypedRandomizer<int>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.Next();
            }

            Helper.PrintCollection(randomNumbers);

            // Assert.
            Assert.IsTrue(randomNumbers.All(number => number >= minValue && number < maxValue));
        }

        [Test]
        public void WhenGettingNextInt32_AndInRangeWithMax_ThenRandomNumbersAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const int minValue = 0;
            const int maxValue = int.MaxValue / 2;
            var randomNumbers = new int[samplesCount];
            var intRandomizer = _randomService.GetNumberRandomizer<int>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = intRandomizer.Next(maxValue);
            }

            Helper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            Assert.IsTrue(randomNumbers.All(number => number >= minValue && number < maxValue));
        }

        [Test]
        public void WhenGettingNextInt32_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const int minValue = int.MinValue;
            const int maxValue = int.MaxValue;
            var randomNumbers = new int[samplesCount];
            var intRandomizer = _randomService.GetNumberRandomizer<int>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = intRandomizer.Next(minValue, maxValue);
            }

            Helper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            Assert.IsTrue(randomNumbers.All(number => number < maxValue));
        }

        [Test]
        public void WhenGettingNextSingle_AndInDefaultRange_ThenRandomNumbersAreNotTheSame(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const float minValue = 0;
            const float maxValue = float.MaxValue;
            var randomNumbers = new float[samplesCount];
            var floatRandomizer = _randomService.GetTypedRandomizer<float>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = floatRandomizer.Next();
            }

            Helper.PrintCollection(randomNumbers);

            // Assert.
            Assert.IsTrue(randomNumbers.All(number => number >= minValue && number < maxValue));
        }

        [Test]
        public void WhenGettingNextSingle_AndInRangeWithMin_ThenRandomNumbersAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const float minValue = 0;
            const float maxValue = float.MaxValue;
            var randomNumbers = new float[samplesCount];
            var floatRandomizer = _randomService.GetNumberRandomizer<float>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = floatRandomizer.Next(maxValue);
            }

            Helper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            Assert.IsTrue(randomNumbers.All(number => number >= minValue && number < maxValue));
        }

        [Test]
        public void WhenGettingNextSingle_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const float minValue = float.MinValue;
            const float maxValue = float.MaxValue;
            var randomNumbers = new float[samplesCount];
            var floatRandomizer = _randomService.GetNumberRandomizer<float>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = floatRandomizer.Next(minValue, maxValue);
            }

            Helper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            Assert.IsTrue(randomNumbers.All(number => number >= minValue && number < maxValue));
        }
    }
}