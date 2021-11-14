using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UStart.Infrastructure.Migrations
{
    public partial class dominiov1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    razao_social = table.Column<string>(type: "text", nullable: true),
                    cnpj = table.Column<string>(type: "text", nullable: true),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    rua = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: true),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    cidade_id = table.Column<string>(type: "text", nullable: true),
                    cidade_nome = table.Column<string>(type: "text", nullable: true),
                    cep = table.Column<string>(type: "text", nullable: true),
                    fone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    limite_de_credito = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "formas_pagamentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    dias = table.Column<ICollection<string>>(type: "jsonb", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_formas_pagamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orcamento",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_orcamento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    forma_pagamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade_de_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    total_desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_produtos = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orcamento", x => x.id);
                    table.ForeignKey(
                        name: "fk_orcamento_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orcamento_formas_pagamentos_forma_pagamento_id",
                        column: x => x.forma_pagamento_id,
                        principalTable: "formas_pagamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orcamento_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_pedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    forma_pagamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade_de_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    total_desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_produtos = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedido", x => x.id);
                    table.ForeignKey(
                        name: "fk_pedido_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedido_formas_pagamentos_forma_pagamento_id",
                        column: x => x.forma_pagamento_id,
                        principalTable: "formas_pagamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedido_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orcamento_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orcamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    produto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_item = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orcamento_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_orcamento_item_orcamento_orcamento_id",
                        column: x => x.orcamento_id,
                        principalTable: "orcamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orcamento_item_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uuid", nullable: false),
                    produto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_item = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedido_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_pedido_item_pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedido_item_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_orcamento_cliente_id",
                table: "orcamento",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "ix_orcamento_forma_pagamento_id",
                table: "orcamento",
                column: "forma_pagamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_orcamento_usuario_id",
                table: "orcamento",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_orcamento_item_orcamento_id",
                table: "orcamento_item",
                column: "orcamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_orcamento_item_produto_id",
                table: "orcamento_item",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedido_cliente_id",
                table: "pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedido_forma_pagamento_id",
                table: "pedido",
                column: "forma_pagamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedido_usuario_id",
                table: "pedido",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedido_item_pedido_id",
                table: "pedido_item",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedido_item_produto_id",
                table: "pedido_item",
                column: "produto_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orcamento_item");

            migrationBuilder.DropTable(
                name: "pedido_item");

            migrationBuilder.DropTable(
                name: "orcamento");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "formas_pagamentos");
        }
    }
}
