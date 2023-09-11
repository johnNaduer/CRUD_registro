import { Component, OnInit } from '@angular/core'; // Importa Component y OnInit de @angular/core
import { HttpClient } from '@angular/common/http'; // Importa HttpClient de @angular/common/http

interface Usuario {
  id: number | string;
  nombre: string;
  clave: string;
}


@Component({ // Define el decorador @Component para el componente
  selector: 'app-root', // Define el selector del componente
  templateUrl: './app.component.html', // Define la plantilla HTML del componente
  styleUrls: ['./app.component.css'] // Define los estilos CSS del componente
})
export class AppComponent implements OnInit { // Exporta la clase AppComponent e implementa OnInit
  title = 'myapp'; // Define una propiedad title con el valor 'myapp'
  msg: string = ''; // Define una propiedad msg con el valor inicial ''
  usuarios: Usuario[] = []; //almacenar lista de usuarios
  
  /*
  id: number | string = ''; //debe ser number y no int
  nombre: string = ''; // Agrega esta propiedad
  clave: string = '';  // Agrega esta propiedad
  // Nuevas propiedades para la actualización de usuario
  
  idActualizar: number | string = '';
  nuevoNombre: string = '';
  nuevaClave: string = '';

  idEliminar: number | string = ''; // Agrega la propiedad para el ID de usuario a eliminar
  */
constructor(private http: HttpClient) {} // Define el constructor e inyecta HttpClient
 
  ngOnInit() { // Define el método ngOnInit que se ejecuta cuando se inicializa el componente
    this.getMessage(); // Llama al método getMessage
}

getMessage() {
  const path = 'http://localhost:5298/api/usuarios';
  this.http.get<Usuario[]>(path).subscribe(
    (response) => { // Parsea automáticamente la respuesta como un arreglo de usuarios
      this.usuarios = response; // Asigna la respuesta a la propiedad usuarios
    },
    (error) => {
      console.error(error);
    }
  );
}
  
  // Variables para controlar el estado del modal de confirmación
  isConfirmationModalOpen: boolean = false;
  itemToDelete: any; // Aquí puedes almacenar el elemento a eliminar

  // Función para abrir el modal de confirmación
  openConfirmationModal(item: any) {
    this.itemToDelete = item;
    this.isConfirmationModalOpen = true;
  }

  // Función para cerrar el modal de confirmación
  closeConfirmationModal() {
    this.isConfirmationModalOpen = false;
    this.itemToDelete = null;
  }

  // Función que se ejecuta cuando se confirma la eliminación
  confirmDeletion(confirmed: boolean) {
    if (confirmed) {
      // Aquí puedes realizar la lógica para eliminar el elemento
      console.log('Eliminar elemento:', this.itemToDelete);

      // Luego, puedes agregar la lógica para eliminar el elemento de tu lista de usuarios
      // Por ejemplo, si tienes un servicio para eliminar usuarios, llámalo aquí
    }
    this.closeConfirmationModal(); // Cierra el modal después de la confirmación
  }


}
