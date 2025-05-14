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

### Parámetros

1. **Mantenimiento de Tipos de Gasto**: Calcula automáticamente el código siguiente para cada nuevo tipo de gasto.
2. **Mantenimiento de Usuarios**: Solicita los campos identificación, nombre, apellido, login, password, fecha nacimiento, dirección, correo electrónico y teléfono.
3. **Fondo Monetario**: Puede ser una cuenta bancaria o un fondo de caja menúda.
4. **Movimiento Presupuesto por Usuario y Tipo de Gasto**: Solicita un mes específico para indicar el gasto y presupuesto (solo del usuario que accede al sistema).
5. **Movimiento Registro de Gastos**:
   - Encabezado: Ingresa fecha, fondo monetario, observaciones, nombre de comercio, tipo de documento.
   - Detalle: Coloca el Tipo de Gasto y monto.
6. **Movimiento Depósitos**: Ingresa fecha, fondo monetario y monto.
7. **Consulta de Movimientos**: Solicita un rango de fechas para visualizar todos los movimientos de todos los usuarios (depósitos y gastos).
8. **Gráfico Comparativo de Presupuesto y Ejecución**: Muestra un gráfico tipo barras de lo presupuestado y ejecutado por tipo de gasto.

## Tecnologías Utilizadas

- **Microsoft .NetCore**: Para el desarrollo del backend de la aplicación.
- **SQL Server**: Base de datos utilizada para almacenar los datos.
- **DevExpress**: Componentes de WPF y ASP.NET que se integrarán en el proyecto para la interfaz gráfica.

## Instalación

1. **Instalar Microsoft .NetCore**: Asegúrate de tener instalado el .NetCore o superior.
2. **Configurar SQL Server**: Instala SQL Server y crea una base de datos para almacenar los datos del proyecto.
3. **Clonar el Repositorio**: Utiliza Git para clonar el repositorio en tu máquina local.
4. **Configurar las Dependencias**: Abrir la solución en Visual Studio y asegúrate de que todas las dependencias están instaladas correctamente.

## Desarrollo

### Creación del Proyecto

- **Crear una nueva solución** en Visual Studio.
- **Seleccionar el tipo de proyecto ASP.NET Core Web Application** y configurarlo para utilizar .NetCore o superior.
- **Configurar la base de datos**: Utilizar SQL Server como motor de base de datos.

### Diseño del Menú

1. **Mantenimientos**:
   - Tipos de Gasto: Usar DevExpress GridView para listar y gestionar los tipos de gasto.
   - Usuarios: Usar DevExpress DataGrid y DevExpress FormView para registrar y gestionar usuarios.
   - Fondo Monetario: Usar DevExpress GridControl para listar y gestionar fondos monetarios.
   - Movimientos:
     - Presupuesto por Usuario y Tipo de Gasto: Usar DevExpress GridView para listar y gestionar presupuestos.
     - Registro de Gastos: Usar DevExpress DataGrid y DevExpress FormView para registrar gastos.
     - Depósitos: Usar DevExpress GridControl para listar y gestionar depósitos.

2. **Consultas y Reportes**:
   - Consulta de Movimientos: Usar DevExpress GridView para visualizar movimientos.
   - Gráfico Comparativo de Presupuesto y Ejecución: Usar DevExpress ChartControl para mostrar el gráfico.

### Implementación de Validaciones

1. **Validaciones en Registro de Gastos**: Al guardar, validar si el usuario está sobregirando su presupuesto en algún tipo de gasto.
2. **Validaciones en Depósitos**: Asignar automáticamente al usuario autenticado cuando se ingresa un deposito.

### Integración de DevExpress

1. **Incorporación de Componentes**:
   - Usar DevExpress GridView, DataGrid, FormView, ChartControl y otros componentes para mejorar la interfaz gráfica.
   - Configurar las estilos y colores para una mejor experiencia del usuario.

## Depuración y Mejora

1. **Depuración**: Utilizar la depuración en Visual Studio para identificar y corregir errores en el código.
2. **Mejoras**:
   - Optimización de rendimiento al manejar grandes cantidades de datos.
   - Mejora de la experiencia del usuario con un diseño intuitivo y fácil de navegar.

## Documentación

- **Manual del Usuario**: Describir cómo se utiliza el portal, incluyendo las funcionalidades principales y sus opciones.
- **Guía de Desarrollo**: Detallar los pasos para desarrollar nuevas características o corregir errores.

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