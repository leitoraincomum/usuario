using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using usuario.Data;
using usuario.Model;

namespace usuario.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public UsuarioRepository(Data.UsuarioContext context) 
        {
            _context = context;
            
        }
        public void AdicionaUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscaUsuario(int id)
        {
            return await _context.Usuarios.
                    Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeletaUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}