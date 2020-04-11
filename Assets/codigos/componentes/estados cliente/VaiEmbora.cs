﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NhomNhom {

    public class VaiEmbora : MonoBehaviour
    {
        public Transform ptFolha;

        Cadeiras cadeiras;
        Transform[] pontos;
        int i_ponto;
        ControladorVaiAtePonto ctrlVaiAtePonto;

        bool estaNoPonto;

        public bool FoiEmbora() {
            return i_ponto == pontos.Length - 1 && ctrlVaiAtePonto.estaNoPonto && estaNoPonto;
        }

        void Awake() {
            cadeiras = FindObjectOfType<Cadeiras>();
            ctrlVaiAtePonto = GetComponent<ControladorVaiAtePonto>();
        }

        void Start() {
            ptFolha = GetComponent<ControleCliente>().ptCadeira;

            pontos = cadeiras.ObterRotaSaida(ptFolha);

            ctrlVaiAtePonto.trAlvo = pontos[i_ponto];
            ctrlVaiAtePonto.ativo = true;

            EstadosCliente estado = GetComponent<EstadosCliente>();

            int recompensa = GetComponent<Recompensa>().ObterRecompensa(estado.precoPrato);
            FindObjectOfType<Cofre>().Pagar(recompensa);
            FindObjectOfType<Cadeiras>().AbrirVaga(ptFolha);
        }

        void Update() {
            if (ctrlVaiAtePonto.estaNoPonto && !FoiEmbora() && i_ponto < pontos.Length - 1)
                i_ponto++;

            ctrlVaiAtePonto.trAlvo = pontos[i_ponto];

            Vector3 diff = ctrlVaiAtePonto.trAlvo.position - transform.position;
            estaNoPonto = diff.magnitude < ctrlVaiAtePonto.distanciaMinima;
        }
    }
}
