using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Control_de_Inventario_Listas_Ordenadas
{
    class Inventario
    {
        private Producto first = new Producto();
        private Producto last = new Producto();

        public Inventario()
        {
            first = null;
            last = null;
        }

        public void borrar(int código)
        {
            Producto actual = new Producto();
            actual = first;
            Producto anterior = new Producto();
            anterior = null;
            bool encontrado = false;
            Producto find = null;
            if (first != null)
            {
                while (actual != null || encontrado != true)
                {
                    if (actual.getCódigo() == código)
                    {

                        if (actual == first)
                        {
                            first = first.siguiente;
                        }
                        else if (actual == last)
                        {
                            anterior.siguiente = null;
                            last = anterior;
                        }
                        else
                        {
                            anterior.siguiente = actual.siguiente;
                        }

                        encontrado = true;
                        find = actual;
                    }
                    anterior = actual;
                    actual = actual.siguiente;
                }
            }
            if (!encontrado)
            {
                Console.Write("No se encontró");
            }
        }

        public Producto buscar(int código)
        {
            Producto actual = new Producto();
            actual = first;
            bool encontrado = false;
            Producto find = null;
            if (first != null)
            {
                while (actual != null || encontrado != true)
                {
                    if (actual.getCódigo() == código)
                    {
                        encontrado = true;
                        find = actual;
                    }
                    actual = actual.siguiente;
                }
            }

            if (encontrado)
                return find;
            else
                return null;
        }

        public Producto buscar2(int código)
        {
            Producto p = first;

            while (p != null && p.getCódigo() != código)
                p = p.siguiente;

            return p;
        }

        public string reporte()
        {
            Producto actual = new Producto();
            actual = first;
            string find = null;
            if (first != null)
            {
                while (actual != null)
                {
                    find += actual.ToString();
                    actual = actual.siguiente;
                }
            }
            return find;
        }

        public void agregar(Producto nuevo)
        {
            Producto actual = first;
            if(first == null)
            {
                first = nuevo;
            }
            else
            {
                if(nuevo.getCódigo() < actual.getCódigo())
                {
                    nuevo.siguiente = actual;
                    first = nuevo;
                }
                else
                {
                    try
                    {
                        while (nuevo.getCódigo() > actual.siguiente.getCódigo())
                            actual = actual.siguiente;

                        nuevo.siguiente = actual.siguiente;
                        actual.siguiente = nuevo;
                    }
                    catch
                    {
                        actual.siguiente = nuevo;
                    }
                }
            }
        }


    }
}
