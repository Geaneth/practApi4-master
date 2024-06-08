﻿
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace practApi4_ML
{
    public partial class MLRecomendation
    {
        /// <summary>
        /// model input class for MLRecomendation.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"productoid")]
            public float Productoid { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"rating")]
            public float Rating { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"userid")]
            public float Userid { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLRecomendation.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"productoid")]
            public float Productoid { get; set; }

            [ColumnName(@"rating")]
            public float Rating { get; set; }

            [ColumnName(@"userid")]
            public float Userid { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLRecomendation.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

    }
}
