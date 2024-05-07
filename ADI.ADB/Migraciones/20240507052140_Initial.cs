using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADI.ADB.Migraciones
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Linea",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Linea = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Linea_id",
                        column: x => x.Id_Linea,
                        principalTable: "Linea",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employee_Rol_Id",
                        column: x => x.rol_id,
                        principalTable: "Rol",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Categoria_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Categoria_id",
                        column: x => x.Categoria_id,
                        principalTable: "Categoria",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Proveedor_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Empleado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalFacturado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Compra_Empleado_id",
                        column: x => x.Empleado_id,
                        principalTable: "Empleado",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Compra_Proveedor_id",
                        column: x => x.Proveedor_id,
                        principalTable: "Proveedor",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Cliente_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Empleado_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalFacturado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDescuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_id",
                        column: x => x.Cliente_id,
                        principalTable: "Cliente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_id",
                        column: x => x.Empleado_id,
                        principalTable: "Empleado",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleCompra",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Compra_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompra_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Compra_id",
                        column: x => x.Compra_id,
                        principalTable: "Compra",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DetalleCompra_Producto_id",
                        column: x => x.Producto_id,
                        principalTable: "Producto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Venta_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producto_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Producto_id",
                        column: x => x.Producto_id,
                        principalTable: "Producto",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Venta_id",
                        column: x => x.Venta_id,
                        principalTable: "venta",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Id_Linea",
                table: "Categoria",
                column: "Id_Linea");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_Nombre",
                table: "Categoria",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Nombre",
                table: "Cliente",
                columns: new[] { "Nombre", "Apellido", "Telefono", "Email" },
                unique: true,
                filter: "[Nombre] IS NOT NULL AND [Apellido] IS NOT NULL AND [Telefono] IS NOT NULL AND [Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Empleado_id",
                table: "Compra",
                column: "Empleado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Proveedor_id",
                table: "Compra",
                column: "Proveedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_Compra_id",
                table: "DetalleCompra",
                column: "Compra_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCompra_Producto_id",
                table: "DetalleCompra",
                column: "Producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_Producto_id",
                table: "DetalleVenta",
                column: "Producto_id");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_Venta_id",
                table: "DetalleVenta",
                column: "Venta_id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_Nombre",
                table: "Empleado",
                columns: new[] { "Nombre", "Apellido", "Telefono", "email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_rol_id",
                table: "Empleado",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_Linea_Nombre",
                table: "Linea",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Categoria_id",
                table: "Producto",
                column: "Categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Nombre",
                table: "Producto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_name",
                table: "Proveedor",
                columns: new[] { "Nombre", "Apellido", "Telefono", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Nombre",
                table: "Rol",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_venta_Cliente_id",
                table: "venta",
                column: "Cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_venta_Empleado_id",
                table: "venta",
                column: "Empleado_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleCompra");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Linea");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
