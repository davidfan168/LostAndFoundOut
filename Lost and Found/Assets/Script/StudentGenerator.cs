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

    public GameObject GenerateStudent()
    {
        GameObject student = Instantiate(studentTemplate);
        Student studentInfo = student.GetComponent<Student>();

        int index = Random.Range(0, names.Length);
        name = names[index];
        studentInfo.name = name;

        return student;
    }
}
