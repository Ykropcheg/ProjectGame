using UnityEngine;
using UnityEngine.UI;
public class InitialTasks : MonoBehaviour
{
    public Text tx;
    int i = 0;

    public GameObject SkeletonHead;
    public Transform SpawnPoint;

    void Start(){
        tx.text = "Привет, попробуй подвигаться на A и D";
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && i == 0){
            i += 1;
            tx.text = "Попробуй перепрыгнуть через разлом. Нажми SPACE";
        }
        if (Input.GetKeyDown(KeyCode.Space) && i == 1){
            i += 1;
            tx.text = "Открой сундук на E";
        }
        if (Input.GetKeyDown(KeyCode.E) && i == 2){
            i += 1;
            tx.text = "Перепрыгни разлом с помощью Left Shift в прыжке";
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && i == 3){
            i += 1;
            tx.text = "Ударь пугало на ЛКМ(LMB)";
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && i == 4 ){
            i += 1;
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            Instantiate(SkeletonHead, SpawnPoint.position, Quaternion.identity);
            tx.text = "Ты ранен, чтобы лечиться жми R";
        }
        if (Input.GetKeyDown(KeyCode.R) && i == 5){
            tx.text = "Ты прошел обучение! Можешь приступать к основной игре";
        }
    }
}
