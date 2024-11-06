using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Interfaces;

namespace FactoryMethod;

public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}
