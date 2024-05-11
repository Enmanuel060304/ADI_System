using ADI.ADB.modelos;

namespace ADI.ADB.Vistas;

public class CrearFacturaCompraViewModel
{
    public Compra Compra { get; set; }
    public List<DetalleCompra> DetallesCompra { get; set; }
}