﻿using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public interface IProdutoRepository
{
    IEnumerable<Produto> List();
}
