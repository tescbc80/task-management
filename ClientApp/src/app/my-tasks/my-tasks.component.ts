import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-my-tasks',
  templateUrl: './my-tasks.component.html'
})
export class MyTasksComponent {
  public todotasks: TodoTask[];
  private http: HttpClient;
  private baseUrl: string;

  getStatusName(task: TodoTask) {
    switch (task.status) {

      case 2: return "Done";
      case 1: return "InProgress";
      case 0: return "Todo";

      default: return "Todo";
    }
  }

  removeTask(task: TodoTask, index: number) {
    if (index > -1) {
      const url = `${this.baseUrl}todotask/${task.id}`;
      return this.http.delete(url).subscribe(result => {
        this.todotasks.splice(index, 1);
      }, error => console.error(error));
    }

  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
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
