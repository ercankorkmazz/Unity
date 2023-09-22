using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HareketKontrolu : MonoBehaviour
{
    [SerializeField] public uint userID;                //Kinect kullanıcı ID

    GameObject GameControler_Object;
    GameController myGameController;
    H_1 myHareket_1;
    H_2 myHareket_2;
    H_3 myHareket_3;
    H_4 myHareket_4;
    H_5 myHareket_5;

    //Konumlar
    private Vector3 HeadPosition;           // Baş
    private Vector3 ShoulderCenterPosition; // Omuz Merkezi
    private Vector3 ShoulderLeftPosition;   // Sol Omuz
    private Vector3 ShoulderRightPosition;  // Sağ Omuz
    private Vector3 SpinePosition;          // Omurga
    private Vector3 ElbowLeftPosition;      // Sol Dirsek
    private Vector3 ElbowRightPosition;     // Sağ Dirsek
    private Vector3 WristLeftPosition;      // Sol Bilek
    private Vector3 WristRightPosition;     // Sağ Bilek
    private Vector3 HandLeftPosition;       // Sol El
    private Vector3 HandRightPosition;      // Sağ El 
    private Vector3 HipCenterPosition;      // Kalça Merkezi
    private Vector3 HipLeftPosition;        // Sol Kalça
    private Vector3 HipRightPosition;       // Sağ Kalça
    private Vector3 KneeLeftPosition;       // Sol Diz
    private Vector3 KneeRightPosition;      // Sağ Diz
    private Vector3 AnkleLeftPosition;      // Sol Ayak Bileği
    private Vector3 AnkleRightPosition;     // Sağ Ayak Bileği
    private Vector3 FootLeftPosition;       // Sol Ayak
    private Vector3 FootRightPosition;      // Sağ Ayak

    //Açılar
    public static float Hareket_A { get; set; }
    public static float Hareket_B { get; set; }
    public static float Hareket_C { get; set; }
    public static float Hareket_D { get; set; }
    public static float Hareket_E { get; set; }
    public static float Hareket_F { get; set; }
    public static float Hareket_G { get; set; }
    public static float Hareket_H { get; set; }

    void Start()
    {
        GameControler_Object = GameObject.Find("GameControler"); // Sahnedeki nese adı ile o nesneye ekli Class'a ulaşmaya yarar.
        myGameController = GameControler_Object.GetComponent<GameController>();
    }

    void Update () 
    {
        if (KinectManager.Instance.IsUserDetected())
        {
            userID = KinectManager.Instance.GetPlayer1ID();
            Pozusyonlari_Hesaplat();
            Acilari_Hesaplat();

            if ((Hareket_A > 220f && Hareket_A < 260f) && (Hareket_B > 20f && Hareket_B < 45f) && (Hareket_C > 160f && Hareket_C < 200f) && (Hareket_D > 150f && Hareket_D < 175f) && GameController.Hareket_1 == 1)
            {
                if (myGameController.beklemeSuresi > 0)
                {
                    H_1.beklemeSayaciKontrolu = 1;

                    if (H_1.beklemeSayaci < 0.000001f)
                    {
                        ScoreArttir();
                        GameController.Hareket_1 = 2;
                    }
                }
                else if (myGameController.beklemeSuresi == 0)
                {
                    ScoreArttir();
                    GameController.Hareket_1 = 2;
                }
            }
            else if ((Hareket_A > 275f && Hareket_A < 300f) && (Hareket_B > 25f && Hareket_B < 45f) && (Hareket_C > 140f && Hareket_C < 170f) && (Hareket_D > 245f && Hareket_D < 265f) && GameController.Hareket_2 == 1)
            {
                if (myGameController.beklemeSuresi > 0)
                {
                    H_2.beklemeSayaciKontrolu = 1;

                    if (H_2.beklemeSayaci < 0.000001f)
                    {
                        ScoreArttir();
                        GameController.Hareket_2 = 2;
                    }
                }
                else if (myGameController.beklemeSuresi == 0)
                {
                    ScoreArttir();
                    GameController.Hareket_2 = 2;
                }
            }
            else if ((Hareket_E > 80f && Hareket_E < 130f) && (Hareket_D > 220f && Hareket_D < 270f) && (Hareket_C > 150f && Hareket_C < 190f) && (Hareket_B > 25f && Hareket_B < 45f) && GameController.Hareket_3 == 1)
            {
                if(myGameController.beklemeSuresi > 0)
                {
                    H_3.beklemeSayaciKontrolu = 1;

                    if(H_3.H3_beklemeSayaci < 0.000001f)
                    {
                        ScoreArttir();
                        GameController.Hareket_3 = 2;
                    }
                }
                else if(myGameController.beklemeSuresi == 0)
                {
                    ScoreArttir();
                    GameController.Hareket_3 = 2;
                }
            }
            else if ((Hareket_A > 250f && Hareket_A < 280f) && (Hareket_B > 25f && Hareket_B < 50f) && (Hareket_C > 170f && Hareket_C < 190f) && (Hareket_D > 255f && Hareket_D < 275f) && GameController.Hareket_4 == 1)
            {
                if (myGameController.beklemeSuresi > 0)
                {
                    H_4.beklemeSayaciKontrolu = 1;

                    if (H_4.beklemeSayaci < 0.000001f)
                    {
                        ScoreArttir();
                        GameController.Hareket_4 = 2;
                    }
                }
                else if (myGameController.beklemeSuresi == 0)
                {
                    ScoreArttir();
                    GameController.Hareket_4 = 2;
                }
            }
            else if ((Hareket_E > 300f && Hareket_E < 330f) && (Hareket_D > 20f && Hareket_D < 50f) && (Hareket_C > 145f && Hareket_C < 170f) && (Hareket_B > 27f && Hareket_B < 50f) && GameController.Hareket_5 == 1)
            {
                if (myGameController.beklemeSuresi > 0)
                {
                    H_5.beklemeSayaciKontrolu = 1;

                    if (H_5.beklemeSayaci < 0.000001f)
                    {
                        ScoreArttir();
                        GameController.Hareket_5 = 2;
                    }
                }
                else if (myGameController.beklemeSuresi == 0)
                {
                    ScoreArttir();
                    GameController.Hareket_5 = 2;
                }
            }
            else
            {
                H_1.beklemeSayaciKontrolu = 0;
                H_2.beklemeSayaciKontrolu = 0;
                H_3.beklemeSayaciKontrolu = 0;
                H_4.beklemeSayaciKontrolu = 0;
                H_5.beklemeSayaciKontrolu = 0;
            }
        }
    }

    public void Pozusyonlari_Hesaplat ()
    {
        HeadPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, HeadIndex);                        // Baş
        ShoulderCenterPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, ShoulderCenterIndex);    // Omuz Merkezi
        ShoulderLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, ShoulderLeftIndex);        // Sol Omuz
        ShoulderRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, ShoulderRightIndex);      // Sağ Omuz
        SpinePosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, SpineIndex);                      // Omurga
        ElbowLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, ElbowLeftIndex);              // Sol Dirsek
        ElbowRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, ElbowRightIndex);            // Sağ Dirsek
        WristLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, WristLeftIndex);              // Sol Bilek
        WristRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, WristRightIndex);            // Sağ Bilek
        HandLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, HandLeftIndex);                // Sol El
        HandRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, HandRightIndex);              // Sağ El 
        HipCenterPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, HipCenterIndex);              // Kalça Merkezi
        HipLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, HipLeftIndex);                  // Sol Kalça
        HipRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, HipRightIndex);                // Sağ Kalça
        KneeLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, KneeLeftIndex);                // Sol Diz
        KneeRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, KneeRightIndex);              // Sağ Diz
        AnkleLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, AnkleLeftIndex);              // Sol Ayak Bileği
        AnkleRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, AnkleRightIndex);            // Sağ Ayak Bileği
        FootLeftPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, FootLeftIndex);                // Sol Ayak
        FootRightPosition = KinectManager.Instance.GetRawSkeletonJointPos(userID, FootRightIndex);              // Sağ Ayak
    }

    public void Acilari_Hesaplat()
    {
        Hareket_A = GetSegmentAngle(HeadPosition, ShoulderLeftPosition, ElbowLeftPosition, "x", "y");
        Hareket_B = GetSegmentAngle(KneeRightPosition, HipCenterPosition, KneeLeftPosition, "x", "y");
        Hareket_C = GetSegmentAngle(HeadPosition, SpinePosition, HipCenterPosition, "x", "y");
        Hareket_D = GetSegmentAngle(ShoulderCenterPosition, ElbowRightPosition, HandRightPosition, "x", "y");
        Hareket_E = GetSegmentAngle(ShoulderCenterPosition, ElbowLeftPosition, HandLeftPosition, "x", "y");
        Hareket_F = GetSegmentAngle(HipLeftPosition, KneeLeftPosition, AnkleLeftPosition, "x", "y");
        Hareket_G = GetSegmentAngle(HeadPosition, ShoulderRightPosition, ElbowRightPosition, "x", "y");
    }

    public float GetSegmentAngle(Vector3 joint0, Vector3 joint1, Vector3 joint2, string dimension1, string dimension2)
    {
        Vector2 from = new Vector2();
        Vector2 to = new Vector2();

        if (dimension1 == "x" && dimension2 == "y")
        {
            from = new Vector2(joint0.x - joint1.x, joint0.y - joint1.y);
            to = new Vector2(joint2.x - joint1.x, joint2.y - joint1.y);
        }
        else if (dimension1 == "y" && dimension2 == "z")
        {
            from = new Vector2(joint0.y - joint1.y, joint0.z - joint1.z);
            to = new Vector2(joint2.y - joint1.y, joint2.z - joint1.z);
        }
        else if (dimension1 == "x" && dimension2 == "z")
        {
            from = new Vector2(joint0.x - joint1.x, joint0.z - joint1.z);
            to = new Vector2(joint2.x - joint1.x, joint2.z - joint1.z);
        }

        float roundedAngle = Vector2.Angle(from, to); // yaklaşık açı, yuvarlanmış, ortalama
        Vector3 cross = Vector3.Cross((joint1 - joint0), (joint1 - joint2)); // kesişim noktaları

        if (Vector3.Dot(cross, Vector3.forward) > 0f)
            roundedAngle = 360f - roundedAngle;

        return roundedAngle;
    }

    public void ScoreArttir()
    {
        GameController.Skor += myGameController.SkorArttirmaMiktari;
        myGameController.SkorText.text = GameController.Skor.ToString();
    }

    public const int HipCenterIndex = 0,
        SpineIndex = 1,
        ShoulderCenterIndex = 2,
        HeadIndex = 3,
        ShoulderLeftIndex = 4,
        ElbowLeftIndex = 5,
        WristLeftIndex = 6,
        HandLeftIndex = 7,
        ShoulderRightIndex = 8,
        ElbowRightIndex = 9,
        WristRightIndex = 10,
        HandRightIndex = 11,
        HipLeftIndex = 12,
        KneeLeftIndex = 13,
        AnkleLeftIndex = 14,
        FootLeftIndex = 15,
        HipRightIndex = 16,
        KneeRightIndex = 17,
        AnkleRightIndex = 18,
        FootRightIndex = 19,
        jointCount = 20;
}
