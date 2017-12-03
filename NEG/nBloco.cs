using DAO;
using ENT;
using System;
using System.Collections.Generic;

namespace NEG
{
    public class nBloco
    {
        #region Assinaturas
        /// <summary>
        /// *********Criação*************
        /// Autor: Euler Vital
        /// Motivo: Classe Negocio de Bloco
        /// Data Criação: 12/08/2017
        /// ********Alteração************
        /// Autor: 
        /// Motivo:
        /// Data Criação:
        /// ********Alteração************
        /// Autor: 
        /// Motivo:
        /// Data Criação:
        /// ********Alteração************
        /// Autor: 
        /// Motivo:
        /// Data Criação:
        /// </summary>
        #endregion

        private string caracteres = @"qwertyuiopéèúùíìòóaáàsdfghjklçãâôõûêzxcvbnm";
        private string caracteresEspecias = @",.;:~^}º]{[ª+=§-_)(*&¨¬%¢$£#³²@¹!'/\ °?|´`";
        private char aspasDuplas = '"';
        private string numeros = "0123456789";

        public nBloco()
        {
            caracteresEspecias += aspasDuplas.ToString();
        }

        public static List<eBloco> Bloco_GET(eBloco obj)
        {
            try
            {
                dBloco db = new dBloco();
                return db.Bloco_GET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Bloco_SET(eBloco obj)
        {
            try
            {
                dBloco db = new dBloco();
                return db.Bloco_SET(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RetornaNumeros(string valor)
        {
            caracteres += caracteresEspecias;

            char[] arrayChar = caracteres.ToCharArray();

            foreach (var caracter in arrayChar)
            {
                valor = valor.ToLower().Replace(caracter.ToString(), "");
            }
            return valor.ToUpper();
        }

        public string RetornaLetras(string valor)
        {
            numeros += caracteresEspecias;

            char[] arrayChar = numeros.ToCharArray();

            foreach (var caracter in arrayChar)
            {
                valor = valor.ToLower().Replace(caracter.ToString(), "");
            }
            return valor.ToUpper();
        }

        public string RetornaNumerosLetras(string valor)
        {
            char[] arrayChar = caracteresEspecias.ToCharArray();

            foreach (var caracter in arrayChar)
            {
                valor = valor.ToLower().Replace(caracter.ToString(), "");
            }
            return valor.ToUpper();
        }
    }
}
