using System.Collections.Generic;
using UnityEngine;

/// <summary> <see href="http://surl.li/pgsrr">Кривая Безье</see>.</summary>
public class BezierCurve
{
    /// <summary> Таблица значений факториалов (max = 16).</summary>
    private static readonly float[] Factorial = new float[]
    {
        1.0f,
        1.0f,
        2.0f,
        6.0f,
        24.0f,
        120.0f,
        720.0f,
        5040.0f,
        40320.0f,
        362880.0f,
        3628800.0f,
        39916800.0f,
        479001600.0f,
        6227020800.0f,
        87178291200.0f,
        1307674368000.0f,
        20922789888000.0f,
    };

    /// <summary> <see href="http://surl.li/pgslu">Число сочетаний</see> (биномиальный коэффициент).</summary>
    /// <remarks> Максимальное значение параметров n и i равно 16.</remarks>
    /// <returns> Возвращает число сочетаний.</returns>
    private static float Binomial(int n, int i) =>
        Factorial[n] / (Factorial[i] * Factorial[n - i]);

    /// <summary> <see href="http://surl.li/pgslp">Базисные многочлены Бернштейна</see>.</summary>
    /// <returns> Возвращает значения базисных многочленов Бернштейна.</returns>
    private static float Bernstein(int n, int i, float t) =>
        Binomial(n, i) * Mathf.Pow(t, i) * Mathf.Pow(1 - t, n - i);

    /// <summary> <see href="http://surl.li/pgsqi">Точка Безье</see>.</summary>
    /// <param name="t"> Интервал кривой.</param>
    /// <param name="controlPoints"> Заданный набор контрольных точек.</param>
    /// <returns> Возвращает точку Безье.</returns>
    public static Vector3 Point3(float t, List<Vector3> controlPoints)
    {
        int n = controlPoints.Count - 1;
        if (n > 16)
        {
            Debug.Log("You have used more than 16 control points. The maximum control points allowed is 16.");
            controlPoints.RemoveRange(16, controlPoints.Count - 16);
        }

        if (t <= 0) return controlPoints[0];
        if (t >= 1) return controlPoints[n];

        var p = new Vector3();

        for (int i = 0; i < controlPoints.Count; i++)
        {
            Vector3 bn = Bernstein(n, i, t) * controlPoints[i];
            p += bn;
        }
        return p;
    }

    /// <summary> Список точек, представляющих кривую Безье.</summary>
    /// <param name="controlPoints"> Контрольные точки.</param>
    /// <param name="interval"> Интервал. По умолчанию 0.01, что соответсвует 100 точкам на кривой Безье.</param>
    /// <returns> Возвращает список точек, представляющих кривую Безье.</returns>
    public static List<Vector3> PointList3(List<Vector3> controlPoints, float interval = 0.01f)
    {
        int n = controlPoints.Count - 1;
        if (n > 16)
        {
            Debug.Log("You have used more than 16 control points. The maximum control points allowed is 16.");
            controlPoints.RemoveRange(16, controlPoints.Count - 16);
        }

        var points = new List<Vector3>();
        for (float t = 0.0f; t <= 1.0f + interval - 0.0001f; t += interval)
        {
            var p = new Vector3();
            for (int i = 0; i < controlPoints.Count; ++i)
            {
                Vector3 bn = Bernstein(n, i, t) * controlPoints[i];
                p += bn;
            }
            points.Add(p);
        }
        return points;
    }

    /// <summary> <see href="http://surl.li/pgsqi">Точка Безье</see>.</summary>
    /// <param name="t"> Интервал кривой.</param>
    /// <param name="controlPoints"> Заданный набор контрольных точек.</param>
    /// <returns> Возвращает точку Безье.</returns>
    public static Vector2 Point2(float t, List<Vector2> controlPoints)
    {
        int n = controlPoints.Count - 1;
        if (n > 16)
        {
            Debug.Log("You have used more than 16 control points. The maximum control points allowed is 16.");
            controlPoints.RemoveRange(16, controlPoints.Count - 16);
        }

        if (t <= 0) return controlPoints[0];
        if (t >= 1) return controlPoints[controlPoints.Count - 1];

        var p = new Vector2();

        for (int i = 0; i < controlPoints.Count; ++i)
        {
            Vector2 bn = Bernstein(n, i, t) * controlPoints[i];
            p += bn;
        }
        return p;
    }

    /// <summary> Список точек, представляющих кривую Безье.</summary>
    /// <param name="controlPoints"> Контрольные точки.</param>
    /// <param name="interval"> Интервал. По умолчанию 0.01, что соответсвует 100 точкам на кривой Безье.</param>
    /// <returns> Возвращает список точек, представляющих кривую Безье.</returns>
    public static List<Vector2> PointList2(List<Vector2> controlPoints, float interval = 0.01f)
    {
        int n = controlPoints.Count - 1;
        if (n > 16)
        {
            Debug.Log("You have used more than 16 control points. The maximum control points allowed is 16.");
            controlPoints.RemoveRange(16, controlPoints.Count - 16);
        }

        var points = new List<Vector2>();
        for (float t = 0.0f; t <= 1.0f + interval - 0.0001f; t += interval)
        {
            var p = new Vector2();
            for (int i = 0; i < controlPoints.Count; ++i)
            {
                Vector2 bn = Bernstein(n, i, t) * controlPoints[i];
                p += bn;
            }
            points.Add(p);
        }
        return points;
    }
}
