﻿using GeneticSharp.Domain.Randomizations;
using System;
using System.Collections;
using System.Linq;

namespace GeneticSharp.Domain.Chromosomes
{
    /// <summary>
    /// Decimal chromosome with fixed count of digits after point and binary values (0 and 1).
    /// </summary>
    public class DecimalChromosome : IntegerChromosome
    {
        public short Decimals { get; set; }
        public readonly int Shift;
        public readonly int m_minValue;
        public readonly int m_maxValue;
        public readonly short m_decimals;
        public int DecimalTens { get; set; }
        //public DecimalChromosome(int min, int max, short decimals) : base(0, (max - min) * (int)Math.Pow(10, decimals), 32, 0)
        public DecimalChromosome(int min, int max, short decimals) : base(0, (max - min) * (int)Math.Pow(10, decimals))
        {
            Decimals = decimals;
            DecimalTens = (int)Math.Pow(10, decimals);
            Shift = min * DecimalTens;

            m_decimals = decimals;
            m_minValue = min;
            m_maxValue = max;
        }

        public override IChromosome CreateNew()
        {
            return new DecimalChromosome(m_minValue, m_maxValue, m_decimals);
        }


        public decimal ToDecimal()
        {
            var intValue = (int)this.ToInteger() + Shift;
            return intValue / (decimal)DecimalTens;
        }
    }
}

