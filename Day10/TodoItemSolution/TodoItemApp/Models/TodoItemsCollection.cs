using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace TodoItemApp.Models
{
	public class TodoItemsCollection : ObservableCollection<TodoItem> // IList<TodoItem>, List<TodoItem>
	{
		public  void CopyFrom(IEnumerable<TodoItem> todoItems)
		{
			this.Items.Clear();	//ObservableCollection<T> 자체가 Items속성을 가지고있음. 모든 데이터 삭제
			
			foreach (TodoItem item in todoItems)
			{
				this.Items.Add(item);	// 데이터 하나씩 다시 추가
			}


			// 데이터 변경알림
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset)); //모두 초기화
		}
	}
}
