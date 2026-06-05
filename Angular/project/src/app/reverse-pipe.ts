import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reverse',
})
export class ReversePipe implements PipeTransform {
  transform(name:string): unknown {
    return name.split('').reverse().join('');
  }
}
