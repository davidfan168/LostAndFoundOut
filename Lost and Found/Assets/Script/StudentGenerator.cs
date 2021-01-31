using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentGenerator : MonoBehaviour
{
    string[] names = new string[] {
"Liam",
"Noah",
"Oliver",
"William",
"Elijah",
"James",
"Benjamin",
"Lucas",
"Mason",
"Ethan",
"Alexander",
"Henry",
"Jacob",
"Michael",
"Daniel",
"Logan",
"Jackson",
"Sebastian",
"Jack",
"Aiden",
"Owen",
"Samuel",
"Matthew",
"Joseph",
"Levi",
"Olivia",
"Emma",
"Ava",
"Sophia",
"Isabella",
"Charlotte",
"Amelia",
"Mia",
"Harper",
"Evelyn",
"Abigail",
"Emily",
"Ella",
"Elizabeth",
"Camila",
"Luna",
"Sofia",
"Avery",
"Mila",
"Aria",
"Scarlett",
"Penelope",
"Layla",
"Chloe",
"Victoria"
};

    public static StudentGenerator Instance;
    private void Awake()
    {
        if (StudentGenerator.Instance == null)
        {
            StudentGenerator.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject studentTemplate;
    public List<Sprite> headImages;
    public List<Sprite> hairImages;
    public List<Sprite> faceImages;

    public GameObject GenerateStudent()
    {
        GameObject student = Instantiate(studentTemplate);
        Student studentInfo = student.GetComponent<Student>();

        int index = Random.Range(0, names.Length);
        name = names[index];
        studentInfo.name = name;

        studentInfo.head = headImages[Random.Range(0, headImages.Count)];
        studentInfo.head = hairImages[Random.Range(0, hairImages.Count)];
        studentInfo.head = faceImages[Random.Range(0, faceImages.Count)];

        return student;
    }
}
