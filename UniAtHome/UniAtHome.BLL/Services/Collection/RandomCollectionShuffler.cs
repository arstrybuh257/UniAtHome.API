using System;
using System.Collections.Generic;
using System.Linq;
using UniAtHome.BLL.Interfaces.Collection;

namespace UniAtHome.BLL.Services.Collection
{
    public class RandomCollectionShuffler : ICollectionShuffler
    {
        public IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            return Shuffle(source, new Random());
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> source, Random rng)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (rng == null)
            {
                throw new ArgumentNullException(nameof(rng));
            }

            return ShuffleIterator(source, rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            IEnumerable<T> source,
            Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
