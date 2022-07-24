using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TrainMove : MonoBehaviour
{
   public enum MovementType
   {
     Moving,
     Lerping
   }
   [SerializeField] Slider speedometer;
    [SerializeField] float sliderVal;
    [SerializeField] float sliderMinVal;
    [SerializeField] float sliderMaxVal;
    [SerializeField] float sliderReturn;
    private Text speedText;
   public MovementType Type = MovementType.Moving; // тип движения по умолчанию
   public MovementPath TrainPath; // используемый путь
   public float maxSpeed = 100; // настройки скорости движения поезда (максимальная скорость)
   public double currentSpeed = 0; //скорость поезда которая  постепенно увеличивается
   public float distance = .1f;// на какое расстояние должен подъехать к маркеру чтобы двигаться дальше
   public float angle;
   private IEnumerator<Transform> pointInPath; // проверка точек
    void Start()
    {
       speedText = speedometer.transform.GetChild(1).GetComponent<Text>();
        if (TrainPath == null) // проверка наличия пути
        {
          Debug.Log("Путь не найден");
          return;
        } //if

         pointInPath = TrainPath.GetNextPathPoint(); // считывание наличия точек
         pointInPath.MoveNext(); //получение положения следующей точки в пути
         
         if(pointInPath.Current == null) //проверка наличия точек
         {
            Debug.Log("Отсутствуют точки");
           return;
    }//if

    transform.position = pointInPath.Current.position; // объект на стартовой точке пути
    }//Start
    void Update()
    {

        if (pointInPath == null || pointInPath.Current == null) //проверка отсутствия пути
      {
        return; // ПУТИ НАЗАД НЕТ!!!!!!
      }//if

     if (Type == MovementType.Moving)
     {
           // float moveKey = Input.GetAxis("Horizontal");
            
                transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, (float)(Time.deltaTime * currentSpeed));   // движение объекта к следующей точке

            if (Input.GetKey(KeyCode.LeftArrow)) //стрелка влево
            {
                currentSpeed = currentSpeed - 0.2;
                sliderVal -= sliderReturn;
                //currentSpeed = speedometer.value;
                //speedText.text = currentSpeed.ToString();
            }
            if (Input.GetKey(KeyCode.RightArrow)) //стрелка вправо
            {
                currentSpeed = currentSpeed + 0.2;
                sliderVal += sliderReturn;

            }
            if (Input.GetKey(KeyCode.A)) // Английская буква A на клавиатуре
            {
                currentSpeed = currentSpeed - 0.2;
                sliderVal -= sliderReturn;
                // currentSpeed = speedometer.value;
                //speedText.text = currentSpeed.ToString();
            }
            if (Input.GetKey(KeyCode.D)) // Английская буква D на клавиатуре 
            {
                currentSpeed = currentSpeed + 0.2;
                sliderVal += sliderReturn;
                // currentSpeed = speedometer.value;
                // speedText.text = currentSpeed.ToString();
            }
            if (currentSpeed < 0) {
              currentSpeed = 0;
            }
            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
     else if (Type == MovementType.Lerping)
     {
        transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * maxSpeed); // движение объекта к следующей точке с ускорением
     }

        var distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude; // проверка близости к точке
         if (distanceSquare < distance * distance)
         {
           pointInPath.MoveNext(); // к следующей точке 
         }

        //SpeedDisplay();
    }//Update

    private void SpeedDisplay()
    {
        if (sliderMaxVal > 75) sliderMaxVal = 75f;
        sliderVal = speedometer.value;
       speedText.text = sliderVal.ToString();
    }
}//class
