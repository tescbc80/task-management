import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-my-tasks',
  templateUrl: './my-tasks.component.html'
})
export class MyTasksComponent {
  public todotasks: TodoTask[];

  getStatusName(task: TodoTask) {
    switch (task.status) {

      case 2: return "Done";
      case 1: return "InProgress";
      case 0: return "Todo";

      default: return "Todo";
    }
  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<TodoTask[]>(baseUrl + 'todotask').subscribe(result => {
      this.todotasks = result;
    }, error => console.error(error));
  }
}

interface TodoTask {
  id: string,
  title: string;
  description: string;
  status: number;
  isComplete: boolean;
}
