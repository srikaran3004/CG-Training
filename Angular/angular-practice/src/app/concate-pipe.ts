import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'concate',
})
export class ConcatePipe implements PipeTransform {
  transform(selected1: string, selected2: string): unknown {
    return `${selected1}-${selected2}`;
  }
}
