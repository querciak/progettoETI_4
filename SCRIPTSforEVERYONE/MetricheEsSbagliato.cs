﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetricheEsSbagliato : MonoBehaviour
{
    public int range;
    const float cosa = 20;
    const float cosa1 = 4;
    public List<Frame> arancione, biancoSbagliato;
    string pathArancione;
    string pathBianco;
    public int frameRate;
    int dimBoa, appoggio, percentuale;
    public float manoSx, manoDx, gomitoSx, gomitoDx, spallaSx, spallaDx;
    int frame_correnteArancione, frame_correnteBianco;
    bool attiva = false;
    public bool sogliaManoSx, sogliaManoDx, sogliaGomitoSx, sogliaGomitoDx, sogliaSpallaSx, sogliaSpallaDx;
    public float threshold;
    public Button play;
    public Button pausa;
    public Button framemin;
    public Text spallaR;
    public Text gomitoR;
    public Text polsoR;
    public Text spallaL;
    public Text gomitoL;
    public Text polsoL;
    public Text percentualeSvolto;
    public Text boolGomitoDx;
    public Text boolGomitoSx;
    public Text boolSpallaDx;
    public Text boolSpallaSx;
    public Text boolPolsoDx;
    public Text boolPolsoSx;
    public Slider soglia;
    public Text valoreSoglia;
    public Slider finestra;
    public Text valoreFinestra;

    void Start()
    {
        pathArancione = Application.dataPath + "/" + "ominoArancioneModello.json";
        pathBianco = Application.dataPath + "/" + "ominoBiancoSbagliato.json";
        arancione = new List<Frame>();
        biancoSbagliato = new List<Frame>();
        appoggio = 1;
        string contentArancione = System.IO.File.ReadAllText(pathArancione);
        string contentBianco = System.IO.File.ReadAllText(pathBianco);
        acquisisci_frame(contentArancione, ref arancione);
        acquisisci_frame(contentBianco, ref biancoSbagliato);
        dimBoa = arancione.Count / 10;
        frameRate = 1;
        threshold = 0.2f;
        range = 100;
        valoreSoglia.text = ((soglia.value) * cosa).ToString("F2") + " cm";
        valoreFinestra.text = ((finestra.value) / 80).ToString("F1") + " sec";
    }

    public void SistemaSoglia(float newthreshold)
    {
        threshold = newthreshold;
    }

    public void SistemaFinestra(float newRange)
    {
        range = Mathf.RoundToInt(newRange);
    }

    void Update()
    {
        valoreSoglia.text = ((soglia.value) * cosa).ToString("F2") + " cm";
        valoreFinestra.text = ((finestra.value) / 80).ToString("F1") + " sec";
        if (attiva == true)
        {
            if (frame_correnteArancione % frameRate == 0)
            {
                //Debug.Log("arancio " + frame_correnteArancione + " bianco " + frame_correnteBianco);
                manoSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione / frameRate].person_0.joint_4.x, arancione[frame_correnteArancione / frameRate].person_0.joint_4.y, arancione[frame_correnteArancione / frameRate].person_0.joint_4.z), new Vector3(biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_4.x, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_4.y, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_4.z));
                manoDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione / frameRate].person_0.joint_7.x, arancione[frame_correnteArancione / frameRate].person_0.joint_7.y, arancione[frame_correnteArancione / frameRate].person_0.joint_7.z), new Vector3(biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_7.x, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_7.y, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_7.z));
                gomitoSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione / frameRate].person_0.joint_3.x, arancione[frame_correnteArancione / frameRate].person_0.joint_3.y, arancione[frame_correnteArancione / frameRate].person_0.joint_3.z), new Vector3(biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_3.x, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_3.y, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_3.z));
                gomitoDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione / frameRate].person_0.joint_6.x, arancione[frame_correnteArancione / frameRate].person_0.joint_6.y, arancione[frame_correnteArancione / frameRate].person_0.joint_6.z), new Vector3(biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_6.x, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_6.y, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_6.z));
                spallaSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione / frameRate].person_0.joint_2.x, arancione[frame_correnteArancione / frameRate].person_0.joint_2.y, arancione[frame_correnteArancione / frameRate].person_0.joint_2.z), new Vector3(biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_2.x, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_2.y, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_2.z));
                spallaDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione / frameRate].person_0.joint_5.x, arancione[frame_correnteArancione / frameRate].person_0.joint_5.y, arancione[frame_correnteArancione / frameRate].person_0.joint_5.z), new Vector3(biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_5.x, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_5.y, biancoSbagliato[frame_correnteBianco / frameRate].person_0.joint_5.z));
                polsoL.text = (manoSx * cosa * cosa1).ToString("F2");
                polsoR.text = (manoDx * cosa * cosa1).ToString("F2");
                gomitoL.text = (gomitoSx * cosa * cosa1).ToString("F2");
                gomitoR.text = (gomitoDx * cosa * cosa1).ToString("F2");
                spallaL.text = (spallaSx * cosa * cosa1).ToString("F2");
                spallaR.text = (spallaDx * cosa * cosa1).ToString("F2");
            }
            if (frame_correnteBianco < biancoSbagliato.Count - 1) frame_correnteBianco++;
            if (frame_correnteArancione < arancione.Count - 1) frame_correnteArancione++;
            if (frame_correnteBianco == biancoSbagliato.Count - 1 && frame_correnteArancione == arancione.Count - 1) { ferma(); frame_correnteArancione = 0; frame_correnteBianco = 0; appoggio = 1; percentuale = 0; }

            if (manoSx < threshold/ cosa1) sogliaManoSx = true; else sogliaManoSx = false;
            if (manoDx < threshold / cosa1) sogliaManoDx = true; else sogliaManoDx = false;
            if (gomitoSx < threshold / cosa1) sogliaGomitoSx = true; else sogliaGomitoSx = false;
            if (gomitoDx < threshold / cosa1) sogliaGomitoDx = true; else sogliaGomitoDx = false;
            if (spallaSx < threshold / cosa1) sogliaSpallaSx = true; else sogliaSpallaSx = false;
            if (spallaDx < threshold / cosa1) sogliaSpallaDx = true; else sogliaSpallaDx = false;
            boolGomitoDx.text = sogliaGomitoSx.ToString();
            boolGomitoSx.text = sogliaGomitoDx.ToString();
            boolSpallaDx.text = sogliaSpallaSx.ToString();
            boolSpallaSx.text = sogliaSpallaDx.ToString();
            boolPolsoDx.text = sogliaManoSx.ToString();
            boolPolsoSx.text = sogliaManoDx.ToString();
            //manca la percentuale
            if (frame_correnteArancione == dimBoa * appoggio)
            {
                if (appoggio <= 0 || appoggio > 10) appoggio = 1;

                //Debug.Log("percentuale: " + 10 * appoggio + "%");
                if (boa(dimBoa * appoggio) == true) percentuale += 10; //else Debug.Log("al frame " + dimBoa * appoggio + " non è stata rispettata la boa");
                //Debug.Log("numero Boa: " + appoggio + " percentuale: " + percentuale + "%");
                ++appoggio;
                percentualeSvolto.text = percentuale.ToString() + "%";
            }


        }



    }

    bool boa(int nFrame)
    {
        int i = 0;
        if (nFrame <= range / 2)//siamo a inizio esercizio
        {
            for (int j = 0; j < range * 2 / 3; ++j)
            {
                if (calcola_distanza(new Vector3(arancione[nFrame].person_0.joint_4.x, arancione[nFrame].person_0.joint_4.y, arancione[nFrame].person_0.joint_4.z), new Vector3(biancoSbagliato[j].person_0.joint_4.x, biancoSbagliato[j].person_0.joint_4.y, biancoSbagliato[j].person_0.joint_4.z)) < threshold/ cosa1)
                {
                    i += 1;
                }
            }
        }
        else if (nFrame > arancione.Count - range / 2 - 1 && nFrame + range / 2 < biancoSbagliato.Count - 1)//siamo a fine esercizio
        {
            for (int j = nFrame - range / 2; j < arancione.Count - 1; ++j)
            {
                if (calcola_distanza(new Vector3(arancione[nFrame].person_0.joint_4.x, arancione[nFrame].person_0.joint_4.y, arancione[nFrame].person_0.joint_4.z), new Vector3(biancoSbagliato[j].person_0.joint_4.x, biancoSbagliato[j].person_0.joint_4.y, biancoSbagliato[j].person_0.joint_4.z)) < threshold/ cosa1)
                {
                    i += 1;
                }
            }
        }
        else if (nFrame > biancoSbagliato.Count - range / 2)//il tipo sta facendo l'es troppo velocemente
        {
            for (int j = nFrame - range / 2; j < biancoSbagliato.Count - 1; ++j)
            {
                if (calcola_distanza(new Vector3(arancione[nFrame].person_0.joint_4.x, arancione[nFrame].person_0.joint_4.y, arancione[nFrame].person_0.joint_4.z), new Vector3(biancoSbagliato[j].person_0.joint_4.x, biancoSbagliato[j].person_0.joint_4.y, biancoSbagliato[j].person_0.joint_4.z)) < threshold/ cosa1)
                {
                    i += 1;
                }
            }
        }
        else if (nFrame > range / 2 || nFrame < arancione.Count - range / 2)//siamo nel vivo dell'esercizio
        {
            for (int j = nFrame - range / 2 + 1; j < nFrame + range / 2; ++j)
            {
                if (calcola_distanza(new Vector3(arancione[nFrame].person_0.joint_4.x, arancione[nFrame].person_0.joint_4.y, arancione[nFrame].person_0.joint_4.z), new Vector3(biancoSbagliato[j].person_0.joint_4.x, biancoSbagliato[j].person_0.joint_4.y, biancoSbagliato[j].person_0.joint_4.z)) < threshold/ cosa1)
                {
                    i += 1;
                }
            }
        }

        if (i > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void parti()
    {
        attiva = true;

        play.GetComponent<Button>().interactable = false;
        pausa.GetComponent<Button>().interactable = true;
        framemin.GetComponent<Button>().interactable = true;
    }
    public void ferma()
    {
        attiva = false;
        play.GetComponent<Button>().interactable = true;
        pausa.GetComponent<Button>().interactable = false;
    }
    public void framePlus()
    {
        attiva = false;
        play.GetComponent<Button>().interactable = true;
        pausa.GetComponent<Button>().interactable = false;
        framemin.GetComponent<Button>().interactable = true;

        if (frame_correnteArancione >= arancione.Count - 1) frame_correnteArancione = 0;
        if (frame_correnteBianco >= biancoSbagliato.Count - 1) frame_correnteBianco = 0;

        manoSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_4.x, arancione[frame_correnteArancione].person_0.joint_4.y, arancione[frame_correnteArancione].person_0.joint_4.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_4.x, biancoSbagliato[frame_correnteBianco].person_0.joint_4.y, biancoSbagliato[frame_correnteBianco].person_0.joint_4.z));
        manoDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_7.x, arancione[frame_correnteArancione].person_0.joint_7.y, arancione[frame_correnteArancione].person_0.joint_7.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_7.x, biancoSbagliato[frame_correnteBianco].person_0.joint_7.y, biancoSbagliato[frame_correnteBianco].person_0.joint_7.z));
        gomitoSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_3.x, arancione[frame_correnteArancione].person_0.joint_3.y, arancione[frame_correnteArancione].person_0.joint_3.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_3.x, biancoSbagliato[frame_correnteBianco].person_0.joint_3.y, biancoSbagliato[frame_correnteBianco].person_0.joint_3.z));
        gomitoDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_6.x, arancione[frame_correnteArancione].person_0.joint_6.y, arancione[frame_correnteArancione].person_0.joint_6.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_6.x, biancoSbagliato[frame_correnteBianco].person_0.joint_6.y, biancoSbagliato[frame_correnteBianco].person_0.joint_6.z));
        spallaSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_2.x, arancione[frame_correnteArancione].person_0.joint_2.y, arancione[frame_correnteArancione].person_0.joint_2.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_2.x, biancoSbagliato[frame_correnteBianco].person_0.joint_2.y, biancoSbagliato[frame_correnteBianco].person_0.joint_2.z));
        spallaDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_5.x, arancione[frame_correnteArancione].person_0.joint_5.y, arancione[frame_correnteArancione].person_0.joint_5.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_5.x, biancoSbagliato[frame_correnteBianco].person_0.joint_5.y, biancoSbagliato[frame_correnteBianco].person_0.joint_5.z));
        polsoL.text = (manoSx * cosa * cosa1).ToString("F2");
        polsoR.text = (manoDx * cosa * cosa1).ToString("F2");
        gomitoL.text = (gomitoSx * cosa * cosa1).ToString("F2");
        gomitoR.text = (gomitoDx * cosa * cosa1).ToString("F2");
        spallaL.text = (spallaSx * cosa * cosa1).ToString("F2");
        spallaR.text = (spallaDx * cosa * cosa1).ToString("F2");

        if (manoSx < threshold / cosa1) sogliaManoSx = true; else sogliaManoSx = false;
        if (manoDx < threshold / cosa1) sogliaManoDx = true; else sogliaManoDx = false;
        if (gomitoSx < threshold / cosa1) sogliaGomitoSx = true; else sogliaGomitoSx = false;
        if (gomitoDx < threshold / cosa1) sogliaGomitoDx = true; else sogliaGomitoDx = false;
        if (spallaSx < threshold / cosa1) sogliaSpallaSx = true; else sogliaSpallaSx = false;
        if (spallaDx < threshold / cosa1) sogliaSpallaDx = true; else sogliaSpallaDx = false;
        boolGomitoDx.text = sogliaGomitoSx.ToString();
        boolGomitoSx.text = sogliaGomitoDx.ToString();
        boolSpallaDx.text = sogliaSpallaSx.ToString();
        boolSpallaSx.text = sogliaSpallaDx.ToString();
        boolPolsoDx.text = sogliaManoSx.ToString();
        boolPolsoSx.text = sogliaManoDx.ToString();
        if (frame_correnteArancione == dimBoa * appoggio)
        {
            if (appoggio <= 0 || appoggio > 10) appoggio = 1;

            //Debug.Log("percentuale: " + 10 * appoggio + "%");
            if (boa(dimBoa * appoggio) == true) percentuale += 10; else Debug.Log("al frame " + dimBoa * appoggio + " non è stata rispettata la boa");
            //Debug.Log("numero Boa: " + appoggio + " percentuale: " + percentuale + "%");
            ++appoggio;
            percentualeSvolto.text = percentuale.ToString() + "%";
        }

        if (frame_correnteBianco < (biancoSbagliato.Count - 1)) frame_correnteBianco++;
        if (frame_correnteArancione < (arancione.Count - 1)) frame_correnteArancione++;
        if (frame_correnteBianco == biancoSbagliato.Count - 1 & frame_correnteArancione == arancione.Count - 1) { frame_correnteArancione++; frame_correnteBianco++; }

        valoreSoglia.text = ((soglia.value) * cosa).ToString("F2") + " cm";
        valoreFinestra.text = ((finestra.value) / 80).ToString("F1") + " sec";
    }
    public void frameMinus()
    {
        if (frame_correnteBianco == 0 & frame_correnteArancione == 0)
        {

            return;
        }
        attiva = false;
        play.GetComponent<Button>().interactable = true;
        pausa.GetComponent<Button>().interactable = false;
        //if (frame_correnteBianco == 0 & frame_correnteArancione == 0) { frame_correnteBianco = biancoSbagliato.Count; frame_correnteArancione = arancione.Count; }

        frame_correnteBianco--;
        frame_correnteArancione--;

        manoSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_4.x, arancione[frame_correnteArancione].person_0.joint_4.y, arancione[frame_correnteArancione].person_0.joint_4.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_4.x, biancoSbagliato[frame_correnteBianco].person_0.joint_4.y, biancoSbagliato[frame_correnteBianco].person_0.joint_4.z));
        manoDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_7.x, arancione[frame_correnteArancione].person_0.joint_7.y, arancione[frame_correnteArancione].person_0.joint_7.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_7.x, biancoSbagliato[frame_correnteBianco].person_0.joint_7.y, biancoSbagliato[frame_correnteBianco].person_0.joint_7.z));
        gomitoSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_3.x, arancione[frame_correnteArancione].person_0.joint_3.y, arancione[frame_correnteArancione].person_0.joint_3.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_3.x, biancoSbagliato[frame_correnteBianco].person_0.joint_3.y, biancoSbagliato[frame_correnteBianco].person_0.joint_3.z));
        gomitoDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_6.x, arancione[frame_correnteArancione].person_0.joint_6.y, arancione[frame_correnteArancione].person_0.joint_6.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_6.x, biancoSbagliato[frame_correnteBianco].person_0.joint_6.y, biancoSbagliato[frame_correnteBianco].person_0.joint_6.z));
        spallaSx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_2.x, arancione[frame_correnteArancione].person_0.joint_2.y, arancione[frame_correnteArancione].person_0.joint_2.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_2.x, biancoSbagliato[frame_correnteBianco].person_0.joint_2.y, biancoSbagliato[frame_correnteBianco].person_0.joint_2.z));
        spallaDx = calcola_distanza(new Vector3(arancione[frame_correnteArancione].person_0.joint_5.x, arancione[frame_correnteArancione].person_0.joint_5.y, arancione[frame_correnteArancione].person_0.joint_5.z), new Vector3(biancoSbagliato[frame_correnteBianco].person_0.joint_5.x, biancoSbagliato[frame_correnteBianco].person_0.joint_5.y, biancoSbagliato[frame_correnteBianco].person_0.joint_5.z));
        polsoL.text = (manoSx * cosa * cosa1).ToString("F2");
        polsoR.text = (manoDx * cosa * cosa1).ToString("F2");
        gomitoL.text = (gomitoSx * cosa * cosa1).ToString("F2");
        gomitoR.text = (gomitoDx * cosa * cosa1).ToString("F2");
        spallaL.text = (spallaSx * cosa * cosa1).ToString("F2");
        spallaR.text = (spallaDx * cosa * cosa1).ToString("F2");

        if (manoSx < threshold / cosa1) sogliaManoSx = true; else sogliaManoSx = false;
        if (manoDx < threshold / cosa1) sogliaManoDx = true; else sogliaManoDx = false;
        if (gomitoSx < threshold / cosa1) sogliaGomitoSx = true; else sogliaGomitoSx = false;
        if (gomitoDx < threshold / cosa1) sogliaGomitoDx = true; else sogliaGomitoDx = false;
        if (spallaSx < threshold / cosa1) sogliaSpallaSx = true; else sogliaSpallaSx = false;
        if (spallaDx < threshold / cosa1) sogliaSpallaDx = true; else sogliaSpallaDx = false;

        boolGomitoDx.text = sogliaGomitoSx.ToString();
        boolGomitoSx.text = sogliaGomitoDx.ToString();
        boolSpallaDx.text = sogliaSpallaSx.ToString();
        boolSpallaSx.text = sogliaSpallaDx.ToString();
        boolPolsoDx.text = sogliaManoSx.ToString();
        boolPolsoSx.text = sogliaManoDx.ToString();

        if (frame_correnteBianco > 0) frame_correnteBianco--;
        if (frame_correnteArancione > 0) frame_correnteArancione--;

        valoreSoglia.text = ((soglia.value) * cosa).ToString("F2") + " cm";
        valoreFinestra.text = ((finestra.value) / 80).ToString("F1") + " sec";
    }

    float calcola_distanza(Vector3 posArancione, Vector3 posBianco)
    {
        float distanza = 0;
        Vector3 delta_pos = new Vector3(posArancione.x - posBianco.x, posArancione.y - posBianco.y, posArancione.z - posBianco.z);

        distanza = Mathf.Sqrt(delta_pos.x * delta_pos.x + delta_pos.y * delta_pos.y + delta_pos.z * delta_pos.z);

        return distanza;
    }



    void acquisisci_frame(string contents, ref List<Frame> lista)
    {
        int i = 0;
        int pos = 0;
        int el = 0;
        do
        {
            int ini = contents.IndexOf("frame", pos);
            int dif = contents.IndexOf('"', ini) - ini;
            contents = contents.Remove(ini, dif);
            contents = contents.Insert(ini, "frame_primo");

            FrameWrap wrapper = JsonUtility.FromJson<FrameWrap>(contents);

            lista.Add(wrapper.frame_primo);
            i++;
            el = contents.IndexOf("frame", ini + 100);
            contents = contents.Remove(contents.IndexOf('{', 0) + 1, el - (contents.IndexOf('{', 0) + 2));
        } while (contents.IndexOf("frame", 100) > 0);
    }

}
