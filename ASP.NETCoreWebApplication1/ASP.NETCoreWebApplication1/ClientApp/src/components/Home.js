import React, {useEffect, useState} from 'react';
import Invoice from './Invoice';

const test = {
  id: 1,
  senderName: 'string',
  senderSurname: 'string',
  senderAddress: 'string',
  senderIban: 'string',
  senderCall: 'string',
  senderModel: 'string',
  receiverName: 'string',
  receiverSurname: 'string',
  receiverAddress: 'string',
  receiverIban: 'string',
  receiverCall: 'string',
  receiverModel: 'string',
  currency: 'EUR',
  amount: 40,
  urgent: true,
  executionDate: '2022-05-16T13:23:28.696',
};

export function Home() {
  const [data, setData] = useState([]);

  const getData = async () => {
    const response = await fetch('/api/orders');
    const data = await response.json();
    setData(data);
  };

  console.log(data);

  const sortBy = (key, direction) => {
    console.log('key', key);
    if (direction) {
      setData(prev =>
        prev.sort((a: any, b: any) => (a[key] > b[key] ? 1 : -1)),
      );
    } else {
      setData(prev =>
        prev.sort((a: any, b: any) => (a[key] > b[key] ? -1 : 1)),
      );
    }
  };

  useEffect(() => {
    getData();
  }, []);
  return (
    <div>
      <div className={'d-flex flex-row justify-content-around mb-4'}>
        <button
          className={'btn btn-secondary'}
          onClick={() => sortBy('SenderName', true)}>
          Sort By First name
        </button>
        <button
          className={'btn btn-secondary'}
          onClick={() => sortBy('SenderSurname', true)}>
          Sort By Last name
        </button>
        <button
          className={'btn btn-secondary'}
          onClick={() => sortBy('Amount', false)}>
          Sort By Amount
        </button>
        <button
          className={'btn btn-secondary'}
          onClick={() => sortBy('ExecutionDate', true)}>
          Sort By Date
        </button>
      </div>

      <table className={'table table-bordered'}>
        <tbody>
          {data.map(x => (
            <Invoice key={x.Id} invoice={x} />
          ))}
        </tbody>
      </table>
    </div>
  );
}
