﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OzonEdu.MerchendiseService.Domain.Models
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public long Id { get; private set; }

        protected Enumeration(long id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public static bool operator ==(Enumeration a, Enumeration b) => a is not null && a.Equals(b);

        public static bool operator !=(Enumeration a, Enumeration b) => !(a == b);

        public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);

    }
}