public static class MyMath
{
    public static bool GetRandomResult(float percent)
    {
        if(percent > 100)
        {
            percent = 100;
        }

        if(percent < 0)
        {
            percent = 0;
        }

        float randomRoll = UnityEngine.Random.Range(0f, 100f);

        return percent >= randomRoll;
    }
}
