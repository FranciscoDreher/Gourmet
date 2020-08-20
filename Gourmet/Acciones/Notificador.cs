using System;
using System.Collections.Generic;

namespace Gourmet
{
    public class Notificador : IAccion
    {
        private Recetario recetario;

        public Recetario Recetario
        {
            private set { recetario = value; }
            get { return recetario; }
        }

        private bool activa;

        public virtual bool Activa
        {
            set { activa = value; }
            get { return activa; }
        }

        private Comensal comensal;

        public Comensal Comensal
        {
            private set { comensal = value; }
            get { return comensal; }
        }

        private EmailSender emailSender;

        public EmailSender EmailSender
        {
            private set { emailSender = value; }
            get { return emailSender; }
        }

        public Notificador()
        {

        }

        public Notificador(Comensal comensal, EmailSender emailSender)
        {
            this.comensal = comensal;
            this.activa = true;
            this.emailSender = emailSender;
        }

        public Notificador(Recetario recetario, Comensal comensal)
        {
            this.recetario = recetario;
            this.comensal = comensal;
            this.activa = true;
        }

        public void AddSuscriptor(Comensal comensal)
        {
            this.comensal = comensal;
        }

        public void SuscribirARecetario(Recetario recetario)
        {
            this.recetario = recetario;
        }

        public void Activar()
        {
            this.activa = true;
        }

        public virtual void Desactivar()
        {
            this.activa = false;
        }

        public virtual void EjecutarAccion(Comida comida, Recetario recetario)
        {
            bool coincidePerfil = this.comensal.EsApto(comida);

            if(activa && coincidePerfil)
            {
                this.recetario = recetario;
                this.emailSender.SendMail("mensaje");
            }
        }
    }
}