﻿using System.Linq;

namespace PokerHand.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PokerPlayerTests
    {
        [Test]
        public void Tests()
        {
            var player = new PokerPlayer("name");

            var hand = player.GenerateNewHand();

            Assert.IsTrue(hand.Count > 0);
        }

        [Test]
        public void GameTest()
        {
            var game = new PokerGame("name1", "name2");
        }

        [Test]
        public void StraightTest()
        {
            var game = new PokerGame("name1", "name2");

            var result = game.HasStraight(new List<Card>
            {
                new Card { Value = CardValue.Four, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Five, Suit = Suit.Hearts },
                new Card { Value = CardValue.Seven, Suit = Suit.Spades },
                new Card { Value = CardValue.Six, Suit = Suit.Clubs },
                new Card { Value = CardValue.Three, Suit = Suit.Diamonds }
            });

            Assert.IsTrue(result);
        }

        [Test]
        public void FlushTestReturnsTrue()
        {
            var game = new PokerGame("name1", "name2");

            var result = game.HasFlush(new List<Card>
            {
                new Card { Value = CardValue.Four, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Five, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Seven, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Six, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Three, Suit = Suit.Diamonds }
            });

            Assert.IsTrue(result);
        }

        [Test]
        public void FlushTestReturnsFalse()
        {
            var game = new PokerGame("name1", "name2");

            var result = game.HasFlush(new List<Card>
            {
                new Card { Value = CardValue.Four, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Five, Suit = Suit.Clubs },
                new Card { Value = CardValue.Seven, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Six, Suit = Suit.Spades },
                new Card { Value = CardValue.Three, Suit = Suit.Diamonds }
            });

            Assert.IsFalse(result);
        }

        [Test]
        public void HasAtLeastTwoOfAKindTest()
        {
            var game = new PokerGame("name1", "name2");

            var result = game.HasAtLeastTwoOfAKind(new List<Card>
            {
                new Card { Value = CardValue.Four, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Five, Suit = Suit.Clubs },
                new Card { Value = CardValue.Three, Suit = Suit.Diamonds },
                new Card { Value = CardValue.Six, Suit = Suit.Spades },
                new Card { Value = CardValue.Three, Suit = Suit.Diamonds }
            });

            Assert.IsTrue(result);
        }

        [Test]
        public void TwoOfAKindTest()
        {
            var game = new PokerGame("name1", "name2");
            var list = new List<Card>
            {
                new Card {Value = CardValue.Four, Suit = Suit.Diamonds},
                new Card {Value = CardValue.Five, Suit = Suit.Clubs},
                new Card {Value = CardValue.Three, Suit = Suit.Diamonds},
                new Card {Value = CardValue.Six, Suit = Suit.Spades},
                new Card {Value = CardValue.Three, Suit = Suit.Diamonds}
            };

            var enumerable = new List<CardValue>
            {
                CardValue.Three,
                CardValue.Five,
                CardValue.Four,
                CardValue.Nine
            };

            var result = game.CheckForValueMatches(list, distinctValues => enumerable.Count() == 4);

            Assert.IsTrue(result);
        }

        [Test]
        public void ThreeOfAKindTest()
        {
            var game = new PokerGame("name1", "name2");
            var list = new List<Card>
            {
                new Card {Value = CardValue.Four, Suit = Suit.Diamonds},
                new Card {Value = CardValue.Three, Suit = Suit.Clubs},
                new Card {Value = CardValue.Three, Suit = Suit.Diamonds},
                new Card {Value = CardValue.Six, Suit = Suit.Spades},
                new Card {Value = CardValue.Three, Suit = Suit.Diamonds}
            };

            var enumerable = new List<CardValue>
            {
                CardValue.Three,
                CardValue.Five,
                CardValue.Six,
            };

            var result = game.CheckForValueMatches(list, distinctValues => enumerable.Count() == 3);

            Assert.IsTrue(result);
        }
    }
}