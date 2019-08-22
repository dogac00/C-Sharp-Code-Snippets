using System;
using System.Collections.Generic;
using System.Text;
using ideal.Mocks;
using ideal.Pools;
using Xunit;

namespace ideal.Tests
{
    public class ArbitrageTests
    {
        public ArbitrageTests()
        {
            SymbolsArray.Initialize();
            PoolManager.InitializePool();
        }

        [Fact]
        public void ShouldIterateArbitrageCase1()
        {
            MockSistem mockSistem = new MockSistem();

            Arbitrage arbitrage = new Arbitrage(mockSistem);

            arbitrage.IterateSymbols();
        }

        [Fact]
        public void ShouldIterateArbitrageCase2()
        {
            Parameters.IsVadeSpot = true;
            Parameters.IsVade0819 = true;

            MockSistem mockSistem = new MockSistem();

            Arbitrage arbitrage = new Arbitrage(mockSistem);

            arbitrage.IterateSymbols();
        }

        [Fact]
        public void ShouldIterateArbitrageCase3()
        {
            Parameters.IsVade0819 = true;
            Parameters.IsVade0919 = true;
            Parameters.IsVade1019 = true;
            Parameters.IsArbitrageForward = true;
            Parameters.ForwardThreshold = -50;
            Parameters.IsSending = true;

            MockSistem mockSistem = new MockSistem();

            Arbitrage arbitrage = new Arbitrage(mockSistem);

            arbitrage.IterateSymbols();
        }

        [Fact]
        public void ShouldIterateArbitrageCase4()
        {
            Parameters.IsVade0919 = true;
            Parameters.IsVade1019 = true;
            Parameters.IsVade1219 = true;
            Parameters.IsSending = true;
            Parameters.IsArbitrageBackward = true;
            Parameters.BackwardThreshold = -50;
            Parameters.TrackThreshold = 10000;
            Parameters.Delay = 15;

            MockSistem mockSistem = new MockSistem();

            Arbitrage arbitrage = new Arbitrage(mockSistem);

            arbitrage.IterateSymbols();
        }

        [Fact]
        public void ShouldIterateArbitrageCase5()
        {
            Parameters.IsVade0919 = true;
            Parameters.IsVade1019 = true;
            Parameters.IsVade1219 = true;
            Parameters.IsSending = true;
            Parameters.Delay = 12;

            MockSistem mockSistem = new MockSistem();

            Arbitrage arbitrage = new Arbitrage(mockSistem);

            arbitrage.IterateSymbols();
        }
    }
}
