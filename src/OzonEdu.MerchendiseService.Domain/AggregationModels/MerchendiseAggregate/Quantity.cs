﻿using System.Collections.Generic;
using OzonEdu.MerchendiseService.Domain.Models;

namespace OzonEdu.MerchendiseService.Domain.AggregationModels.MerchendiseAggregate
{
    public class Quantity: ValueObject
    {
        public long Value { get; }

        public Quantity(long value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        
        public override string ToString()
        {
            return $"Quantity(${Value})";
        }
    }
}