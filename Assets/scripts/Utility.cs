using System.Collections;
using System.Collections.Generic;

public class Utility {
    public static T[] ShuffleArray<T>(T[] arrayToShuffle, int seed)
    {
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < arrayToShuffle.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, arrayToShuffle.Length);

            T aux = arrayToShuffle[randomIndex];
            arrayToShuffle[randomIndex] = arrayToShuffle[i];
            arrayToShuffle[i] = aux;

        }

        return arrayToShuffle;
    }
}
