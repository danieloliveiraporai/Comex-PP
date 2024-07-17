﻿using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos;

public class ReadProdutoDto
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }
    
    public float PrecoUnitario { get; set; }

    public int Quantidade { get; set; }
}
