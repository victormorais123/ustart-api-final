using Microsoft.EntityFrameworkCore.Migrations;

namespace UStart.Infrastructure.Migrations
{
    public partial class dominiov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orcamento_cliente_cliente_id",
                table: "orcamento");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamento_formas_pagamentos_forma_pagamento_id",
                table: "orcamento");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamento_usuarios_usuario_id",
                table: "orcamento");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamento_item_orcamento_orcamento_id",
                table: "orcamento_item");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamento_item_produtos_produto_id",
                table: "orcamento_item");

            migrationBuilder.DropForeignKey(
                name: "fk_pedido_cliente_cliente_id",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "fk_pedido_formas_pagamentos_forma_pagamento_id",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "fk_pedido_usuarios_usuario_id",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "fk_pedido_item_pedido_pedido_id",
                table: "pedido_item");

            migrationBuilder.DropForeignKey(
                name: "fk_pedido_item_produtos_produto_id",
                table: "pedido_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pedido_item",
                table: "pedido_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pedido",
                table: "pedido");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orcamento_item",
                table: "orcamento_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orcamento",
                table: "orcamento");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cliente",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "preco_unitario",
                table: "orcamento");

            migrationBuilder.RenameTable(
                name: "pedido_item",
                newName: "pedidos_itens");

            migrationBuilder.RenameTable(
                name: "pedido",
                newName: "pedidos");

            migrationBuilder.RenameTable(
                name: "orcamento_item",
                newName: "orcamentos_itens");

            migrationBuilder.RenameTable(
                name: "orcamento",
                newName: "orcamentos");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "clientes");

            migrationBuilder.RenameIndex(
                name: "ix_pedido_item_produto_id",
                table: "pedidos_itens",
                newName: "ix_pedidos_itens_produto_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedido_item_pedido_id",
                table: "pedidos_itens",
                newName: "ix_pedidos_itens_pedido_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedido_usuario_id",
                table: "pedidos",
                newName: "ix_pedidos_usuario_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedido_forma_pagamento_id",
                table: "pedidos",
                newName: "ix_pedidos_forma_pagamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedido_cliente_id",
                table: "pedidos",
                newName: "ix_pedidos_cliente_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamento_item_produto_id",
                table: "orcamentos_itens",
                newName: "ix_orcamentos_itens_produto_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamento_item_orcamento_id",
                table: "orcamentos_itens",
                newName: "ix_orcamentos_itens_orcamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamento_usuario_id",
                table: "orcamentos",
                newName: "ix_orcamentos_usuario_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamento_forma_pagamento_id",
                table: "orcamentos",
                newName: "ix_orcamentos_forma_pagamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamento_cliente_id",
                table: "orcamentos",
                newName: "ix_orcamentos_cliente_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pedidos_itens",
                table: "pedidos_itens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pedidos",
                table: "pedidos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orcamentos_itens",
                table: "orcamentos_itens",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orcamentos",
                table: "orcamentos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_clientes",
                table: "clientes",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_orcamentos_clientes_cliente_id",
                table: "orcamentos",
                column: "cliente_id",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamentos_formas_pagamentos_forma_pagamento_id",
                table: "orcamentos",
                column: "forma_pagamento_id",
                principalTable: "formas_pagamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamentos_usuarios_usuario_id",
                table: "orcamentos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamentos_itens_orcamentos_orcamento_id",
                table: "orcamentos_itens",
                column: "orcamento_id",
                principalTable: "orcamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamentos_itens_produtos_produto_id",
                table: "orcamentos_itens",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedidos_clientes_cliente_id",
                table: "pedidos",
                column: "cliente_id",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedidos_formas_pagamentos_forma_pagamento_id",
                table: "pedidos",
                column: "forma_pagamento_id",
                principalTable: "formas_pagamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedidos_usuarios_usuario_id",
                table: "pedidos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedidos_itens_pedidos_pedido_id",
                table: "pedidos_itens",
                column: "pedido_id",
                principalTable: "pedidos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedidos_itens_produtos_produto_id",
                table: "pedidos_itens",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orcamentos_clientes_cliente_id",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamentos_formas_pagamentos_forma_pagamento_id",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamentos_usuarios_usuario_id",
                table: "orcamentos");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamentos_itens_orcamentos_orcamento_id",
                table: "orcamentos_itens");

            migrationBuilder.DropForeignKey(
                name: "fk_orcamentos_itens_produtos_produto_id",
                table: "orcamentos_itens");

            migrationBuilder.DropForeignKey(
                name: "fk_pedidos_clientes_cliente_id",
                table: "pedidos");

            migrationBuilder.DropForeignKey(
                name: "fk_pedidos_formas_pagamentos_forma_pagamento_id",
                table: "pedidos");

            migrationBuilder.DropForeignKey(
                name: "fk_pedidos_usuarios_usuario_id",
                table: "pedidos");

            migrationBuilder.DropForeignKey(
                name: "fk_pedidos_itens_pedidos_pedido_id",
                table: "pedidos_itens");

            migrationBuilder.DropForeignKey(
                name: "fk_pedidos_itens_produtos_produto_id",
                table: "pedidos_itens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pedidos_itens",
                table: "pedidos_itens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pedidos",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orcamentos_itens",
                table: "orcamentos_itens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orcamentos",
                table: "orcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "pedidos_itens",
                newName: "pedido_item");

            migrationBuilder.RenameTable(
                name: "pedidos",
                newName: "pedido");

            migrationBuilder.RenameTable(
                name: "orcamentos_itens",
                newName: "orcamento_item");

            migrationBuilder.RenameTable(
                name: "orcamentos",
                newName: "orcamento");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "cliente");

            migrationBuilder.RenameIndex(
                name: "ix_pedidos_itens_produto_id",
                table: "pedido_item",
                newName: "ix_pedido_item_produto_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedidos_itens_pedido_id",
                table: "pedido_item",
                newName: "ix_pedido_item_pedido_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedidos_usuario_id",
                table: "pedido",
                newName: "ix_pedido_usuario_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedidos_forma_pagamento_id",
                table: "pedido",
                newName: "ix_pedido_forma_pagamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_pedidos_cliente_id",
                table: "pedido",
                newName: "ix_pedido_cliente_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamentos_itens_produto_id",
                table: "orcamento_item",
                newName: "ix_orcamento_item_produto_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamentos_itens_orcamento_id",
                table: "orcamento_item",
                newName: "ix_orcamento_item_orcamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamentos_usuario_id",
                table: "orcamento",
                newName: "ix_orcamento_usuario_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamentos_forma_pagamento_id",
                table: "orcamento",
                newName: "ix_orcamento_forma_pagamento_id");

            migrationBuilder.RenameIndex(
                name: "ix_orcamentos_cliente_id",
                table: "orcamento",
                newName: "ix_orcamento_cliente_id");

            migrationBuilder.AddColumn<decimal>(
                name: "preco_unitario",
                table: "orcamento",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "pk_pedido_item",
                table: "pedido_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pedido",
                table: "pedido",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orcamento_item",
                table: "orcamento_item",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orcamento",
                table: "orcamento",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cliente",
                table: "cliente",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_orcamento_cliente_cliente_id",
                table: "orcamento",
                column: "cliente_id",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamento_formas_pagamentos_forma_pagamento_id",
                table: "orcamento",
                column: "forma_pagamento_id",
                principalTable: "formas_pagamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamento_usuarios_usuario_id",
                table: "orcamento",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamento_item_orcamento_orcamento_id",
                table: "orcamento_item",
                column: "orcamento_id",
                principalTable: "orcamento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orcamento_item_produtos_produto_id",
                table: "orcamento_item",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedido_cliente_cliente_id",
                table: "pedido",
                column: "cliente_id",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedido_formas_pagamentos_forma_pagamento_id",
                table: "pedido",
                column: "forma_pagamento_id",
                principalTable: "formas_pagamentos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedido_usuarios_usuario_id",
                table: "pedido",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedido_item_pedido_pedido_id",
                table: "pedido_item",
                column: "pedido_id",
                principalTable: "pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_pedido_item_produtos_produto_id",
                table: "pedido_item",
                column: "produto_id",
                principalTable: "produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
