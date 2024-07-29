using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using Firebase.Extensions;


public class AuthManager : MonoBehaviour
{

    public static AuthManager instance;

    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Login")]
    public TMP_Text statusLoginText;
    public TMP_Text confirm1LoginText;
    public TMP_Text confirm2LoginText;
    public TMP_Text confirm3LoginText;


    public void Start()
    {

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            statusLoginText.text = dependencyStatus.ToString();
        });
        Debug.Log("Logando anônimo");
        confirm1LoginText.text = "Logando anônimo!";
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync();
        Debug.Log("Logado!");
        confirm2LoginText.text = "Logado!";
        auth.SignOut();
        Debug.Log("Deslogado");
        confirm3LoginText.text = "Deslogado!";
    }
}

//    async void Start()
//    {
//        Debug.Log("Checando dependencias");
//        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//        {
//            dependencyStatus = task.Result;
//            statusLoginText.text = dependencyStatus.ToString();

//        });
//        Debug.Log("Logando anônimo");
//        confirm1LoginText.text = "Logando anônimo!";
//        var auth = FirebaseAuth.DefaultInstance;
//        await auth.SignInAnonymouslyAsync();
//        Debug.Log("Logado!");
//        confirm2LoginText.text = "Logado!";
//        auth.SignOut();
//        Debug.Log("Deslogado");
//        confirm3LoginText.text = "Deslogado!";
//    }
//}
