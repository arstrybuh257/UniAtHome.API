using System;
using System.Collections.Generic;

namespace UniAtHome.BLL.Interfaces.Collection
{
    public interface ICollectionShuffler
    {
        IEnumerable<T> Shuffle<T>(IEnumerable<T> source);

        IEnumerable<T> Shuffle<T>(IEnumerable<T> source, Random rng);
    }
}
