using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataInternetSaver : MonoBehaviour
{
    private const string WorldTimeAPIURL = "https://worldtimeapi.org/api/ip"; // Adres URL serwisu WorldTimeAPI


    public IEnumerator FetchDateTime()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(WorldTimeAPIURL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("B��d pobierania daty z serwera: " + www.error);
            }
            else
            {
                string jsonString = www.downloadHandler.text;
                DateTime dateTime = ParseDateTimeFromJson(jsonString);
                Debug.Log("Pobrano aktualn� dat� i czas: " + dateTime.ToString());

                int years = dateTime.Year;
                int months = dateTime.Month;
                int days = dateTime.Day;
                int hours = dateTime.Hour;
                int minutes = dateTime.Minute;
                int seconds = dateTime.Second;

                Debug.Log($"Rok: {years}, Miesi�c: {months}, Dzie�: {days}, Godzina: {hours}, Minuta: {minutes}, Sekunda: {seconds}");
                PlayerPrefs.SetString("Time_OUT", dateTime.ToString());
            }
        }
    }

    private DateTime ParseDateTimeFromJson(string jsonString)
    {
        int startIndex = jsonString.IndexOf("datetime") + 12; // Pobranie indeksu pocz�tkowego daty w JSON-ie
        int endIndex = jsonString.IndexOf('"', startIndex); // Pobranie indeksu ko�cowego daty w JSON-ie
        string dateString = jsonString.Substring(startIndex, endIndex - startIndex); // Wyodr�bnienie ci�gu znak�w reprezentuj�cego dat�

        return DateTime.Parse(dateString); // Parsowanie ci�gu znak�w do obiektu DateTime
    }
}