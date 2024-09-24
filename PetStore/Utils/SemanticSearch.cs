using FuzzySharp;
using System;

namespace PetStore.Utils
{
    /// <summary>
    /// Semantic search algorithms
    /// </summary>
    public enum SemanticAlgorithm
    {
        /// <summary>
        /// Ratio
        /// </summary>
        Ratio,
        /// <summary>
        /// Partial ratio
        /// </summary>
        PartialRatio,
        /// <summary>
        /// Token sort ratio
        /// </summary>
        TokenSortRatio,
        /// <summary>
        /// Partial token sort ratio
        /// </summary>
        PartialTokenSortRatio,
        /// <summary>
        /// Token set ratio
        /// </summary>
        TokenSetRatio,
        /// <summary>
        /// Partial token set ratio
        /// </summary>
        PartialTokenSetRatio,
        /// <summary>
        /// Weighted ratio
        /// </summary>
        WeightedRatio
    }

    /// <summary>
    /// Semantic search result class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SemanticResult<T>
    {
        /// <summary>
        /// Analyzed value
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Analysis score
        /// </summary>
        public int Score { get; set; }
    }

    /// <summary>
    /// Methods for semantic search
    /// </summary>
    public static class SemanticSearch
    {
        /// <summary>
        /// Calculate semantic similarity score by algorithm
        /// </summary>
        /// <param name="text1"></param>
        /// <param name="text2"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static int CalculateScore(string text1, string text2, SemanticAlgorithm algorithm)
        {
            text1 = text1.Trim().ToUpper();
            text2 = text2.Trim().ToUpper();
            switch (algorithm)
            {
                case SemanticAlgorithm.Ratio:
                    return Fuzz.Ratio(text1, text2);
                case SemanticAlgorithm.PartialRatio:
                    return Fuzz.PartialRatio(text1, text2);
                case SemanticAlgorithm.TokenSortRatio:
                    return Fuzz.TokenSortRatio(text1, text2);
                case SemanticAlgorithm.PartialTokenSortRatio:
                    return Fuzz.PartialTokenSortRatio(text1, text2);
                case SemanticAlgorithm.TokenSetRatio:
                    return Fuzz.TokenSetRatio(text1, text2);
                case SemanticAlgorithm.PartialTokenSetRatio:
                    return Fuzz.PartialTokenSetRatio(text1, text2);
                case SemanticAlgorithm.WeightedRatio:
                    return Fuzz.WeightedRatio(text1, text2);
                default: throw new NotImplementedException();
            }
        }
    }
}
