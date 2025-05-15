# DevExpressExpenseControl

Este es un proyecto web desarrollado utilizando Microsoft .NetCore,SQL Server, DevExpress, DevExtreme y OpenIddict con la integración de los componentes de una interfaz gráfica atractiva y segura.

## Descripción del Proyecto

El objetivo principal del portal es permitir que varias personas registradas puedan gestionar sus gastos individuales. Cada usuario puede registrar su fondo monetario y registrar gastos generales, incluyendo diferentes tipos de documentos como comprobantes y facturas.

### Espectativa del Menú

1. 
   **Mantenimientos**:
   - Tipos de Gasto: Calcula automáticamente el código siguiente para cada nuevo tipo de gasto.
   - Usuarios: Solicita los campos identificación, nombre, apellido, login, password, fecha nacimiento, dirección, correo electrónico y teléfono.
   - Fondo Monetario: Puede ser una cuenta bancaria o un fondo de caja menúda.
   **Movimientos**:
     - Presupuesto por Usuario y Tipo de Gasto: Solicita un mes específico para indicar el gasto y presupuesto (solo del usuario que accede al sistema).
     - Registro de Gastos: Maneja transacciones en el encabezado y detalle. No se guarda el encabezado sin su detalle, y en el encabezado debe ingresar datos como fecha, fondo monetario, observaciones, nombre de comercio, tipo de documento (comprobante, factura, otro).
     - Depósitos: Ingresa fecha, fondo monetario y monto.
   **Consultas y Reportes**:
     - Consulta de Movimientos: Solicita un rango de fechas para visualizar todos los movimientos de todos los usuarios (depósitos y gastos).
     - Gráfico Comparativo de Presupuesto y Ejecución: Muestra un gráfico tipo barras de lo presupuestado y ejecutado por tipo de gasto.

## Tecnologías Utilizadas

- **Microsoft .NetCore**: Para el desarrollo del backend de la aplicación.
- **SQL Server**: Base de datos utilizada para almacenar los datos.
- **DevExpress**: Componentes de WPF y ASP.NET que se integrarán en el proyecto para la interfaz gráfica.

## Instalación

1. **Instalar Microsoft .NetCore**: Asegúrate de tener instalado el .NetCore o superior.
2. **Configurar SQL Server**: Instala SQL Server y crea una base de datos para almacenar los datos del proyecto.
3. **Clonar el Repositorio**: Utiliza Git para clonar el repositorio en tu máquina local.
4. **Configurar las Dependencias**: Abrir la solución en Visual Studio y asegúrate de que todas las dependencias están instaladas correctamente.

## Planificación del Proyecto

1. **MVP (Minimum Viable Product)**:
   - Implementar la base de datos y el mantenimiento de tipos de gasto.
2. **Funciones Clave**:
   - Registro de usuarios, gestión de fondos monetarios y movimientos.
3. **Tecnologías**:
   - Microsoft .NetCore, SQL Server, DevExpress.
4. **Estructura de Carpetas**:
   - Proyecto principal: `WebPortalControlGastos`
     - Controllers: Controladores principales del proyecto.
     - Models: Entidades y modelos utilizados en el proyecto.
     - Views: Vistas para la interfaz gráfica.
     - Resources: Recursos como imágenes, estilos y configuraciones.

## Conclusión

Este portal web proporciona una solución completa para gestionar gastos individuales de manera eficiente. Utilizando .NetCore, SQL Server y DevExpress, se ha logrado crear una aplicación robusta que cumple con las expectativas del cliente.

---

### Referencias

- [Microsoft .NetCore Documentation](https://docs.microsoft.com/en-us/dotnet/framework/)
- [SQL Server Documentation](https://docs.microsoft.com/en-us/sql/sql-server/)
- [DevExpress Documentation](https://www.devexpress.com/products/net/)

---

Este README proporciona una descripción detallada del proyecto, sus tecnologías utilizadas, y las etapas de desarrollo.