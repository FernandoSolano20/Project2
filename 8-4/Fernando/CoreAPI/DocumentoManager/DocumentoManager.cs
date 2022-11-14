using DataAccess.Crud.Documento;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.DocumentoManager
{
    public class DocumentoManager : BaseManager
    {
        private DocumentoCrudFactory factory;

        public DocumentoManager()
        {
            factory = new DocumentoCrudFactory();
        }

        public void Create(Documento documento)
        {
            try
            {
                documento.Estado = Estado.ACT;
                factory.Create(documento);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Documento RetrieveByID(Documento documento)
        {
            Documento tempDocumento = null;

            try
            {

                tempDocumento = factory.Retrieve<Documento>(documento);

                if (tempDocumento == null)
                {
                    throw new BusinessException("20");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempDocumento;
        }

        public List<Documento> RetrieveByUserID(Documento documento)
        {
            return factory.RetrieveByUserID<Documento>(documento);
        }

        public List<Documento> RetrieveActive()
        {
            var documento = new Documento
            {
                Estado = Estado.ACT
            };
            return factory.RetrieveStatus<Documento>(documento);
        }

        public List<Documento> RetrieveAll()
        {
            return factory.RetrieveAll<Documento>();
        }

        public void Update(Documento documento)
        {
            try
            {
                var tempDocumento = factory.Retrieve<Documento>(documento);

                if (tempDocumento == null)
                {
                    throw new BusinessException("20");
                }
                else
                    factory.Update(documento);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Documento documento)
        {
            try
            {
                var tempDocumento = factory.Retrieve<Documento>(documento);

                if (tempDocumento == null)
                {
                    throw new BusinessException("20");
                }
                else
                    factory.Delete(documento);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void UpdateStatus(Documento documento)
        {
            try
            {
                if (documento.Estado == Estado.ACT)
                    documento.Estado = Estado.DES;
                else
                    documento.Estado = Estado.ACT;

                var tempDocumento = factory.Retrieve<Documento>(documento);

                if (tempDocumento == null)
                {
                    throw new BusinessException("20");
                }
                else
                    factory.UpdateStatus(documento);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
