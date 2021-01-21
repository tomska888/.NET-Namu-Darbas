using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    interface ICatsListProvider
    {
        Task<IList<Breed>> GetBreeds();
    }
}
