using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstPaoloTest.Entities;
using EFCodeFirstPaoloTest.Services.Interfaces;

namespace EFCodeFirstPaoloTest.Services.Interfaces
{
    public interface IPlayerService : IBasePlayerService<Player>
    {
    }
}
