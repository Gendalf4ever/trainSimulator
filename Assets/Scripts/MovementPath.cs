using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementPath : MonoBehaviour
{
    public int movementDirection = 1; // движение вперед
    public int movingTo = 0; // к какой точке двигаться
    public Transform[] points; // массив для точек из которых строится маршрут

    //public float AngleBetween { get; set; } = Vector3.SignedAngle;

    public void OnDrawGizmos() // отображение линий меж точками
    {
      if (points== null || points.Length < 2) // проверяет есть ли что рисовать
      {
          return;
      } //if

      for (var i=1; i < points.Length; i++) // прогоняет все точки массива
      {
      Gizmos.DrawLine(points[i-1].position, points[i].position); // рисует линии меж точками
      } //for
    }//void

    public IEnumerator<Transform> GetNextPathPoint() // положение следующей точки
    {
       if (points == null || points.Length <1 ) // проверка
       {
          yield break; //выход
       }//if
        
       while (true)
       {
           yield return points[movingTo]; // возвращает текущее положение точки

           if(points.Length == 1)
           {
             continue;
           }//if

            if(movingTo <=0) // движение по нарастающей
            {
                movementDirection = 1; // +1 точка
            }
            // else if (movingTo >= points.Length - 1) // движение по убывающей
           //  {
            //   movementDirection = -1; // -1 точка
            // }

             movingTo = movingTo + movementDirection; //диапазон движения от 1 до -1
       }//while
    }

}//class
