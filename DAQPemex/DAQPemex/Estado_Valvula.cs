using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAQPemex
{
    class Estado_Valvula
    {
        bool estadoInicial, estadoAbierto, estadoCerrado;
        int contadorEstable;
        float datosAntiguos;
        float margen;

        public Estado_Valvula():this(2)
        {            
        }
        public Estado_Valvula(float _margen)
        {
            estadoInicial = true;
            estadoAbierto = false;
            estadoCerrado = false;
            datosAntiguos = 0;
            margen = _margen;

        }
        
        
        public bool defineEstado(float datosActuales)
        {
            if (estadoInicial)
            {
                if (validaApertura(datosActuales))
                {
                    // SE ABRIO LA VALVULA
                    estadoInicial = false;
                    estadoAbierto = true;
                    datosAntiguos = 0;
                    return true; // significa que hubo cambio
                    
                }
                else
                {
                    // VALVULA CERRADA
                    datosAntiguos = datosActuales;
                    return false;//sin cambio
                    
                }
            }
            else if (estadoAbierto)
            {
                if (validaEstable(datosActuales))
                {
                    // Se volvio a cerrar la compuerta de la valvula y la presion
                    // se debe de estabilizar despues de un tiempo
                    estadoCerrado = true;
                    estadoAbierto = false;
                    datosAntiguos = datosActuales;
                    return true;// cambio
                    
                }
                else
                {
                    //la valvula sige bajando de presion y todavia no se cierra la compuerta
                    datosAntiguos = datosActuales;
                    return false;
                    
                }
            }
            else if (estadoCerrado)
            {
                datosAntiguos = datosActuales;
                return false;
                
            }
            else
            {
                //ERROR?
                datosAntiguos = datosActuales;
                return false;
            }

            
        }

        private bool validaEstable(float datosActuales)
        {
            if (datosAntiguos - datosActuales <= margen)
            {
                if (contadorEstable > 5)
                {
                    return true;
                }
                contadorEstable++;
                return false;

            }
            contadorEstable = 0;
            return false;
        }

        private bool validaApertura(float datosActuales)
        {
        if ((datosActuales < (datosAntiguos  + margen)) | (datosActuales < (datosAntiguos - margen)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int graficaActiva()
        {
            if (estadoInicial)
            {
                return 3;
            }
            else if (estadoAbierto)
            {
                return 4;
            }
            else if (estadoCerrado)
            {
                return 5;
            }
            else
            {
                throw new InvalidOperationException("Ningun Estado Activo");
            }
        }

        public int curvaActiva()
        {
            if (estadoInicial)
            {
                return 0;
            }
            else if (estadoAbierto)
            {
                return 1;
            }
            else if (estadoCerrado)
            {
                return 2;
            }
            else
            {
                throw new InvalidOperationException("Ningun Estado Activo");
            }

        }

    }

}
