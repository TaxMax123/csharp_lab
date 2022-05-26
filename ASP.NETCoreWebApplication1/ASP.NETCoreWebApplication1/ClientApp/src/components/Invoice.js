import React, {useState} from 'react';

const Invoice = ({invoice}) => {
  const [editMode, setEditMode] = useState(false);
  const [newInvoice, setNewInvoice] = useState(invoice);
  const onChange = (key, value) => {
    setNewInvoice(prev => ({...prev, [key]: value}));
  };
  return (
    <React.Fragment key={invoice.Id}>
      <tr className={'my-3'}>
        <th colSpan={6}>Receiver</th>
        <th style={{display: 'flex', justifyContent: 'space-evenly'}}>
          <button
            type="button"
            className="btn btn-primary btn-sm"
            onClick={() => setEditMode(!editMode)}>
            Edit
          </button>
          <button type="button" className="btn btn-danger btn-sm">
            Delete
          </button>
        </th>
      </tr>

      <tr>
        <th>Name</th>
        <th>Surname</th>
        <th>Address</th>
        <th colSpan={2}>IBAN</th>
        <th>Call</th>
        <th>Model</th>
      </tr>
      <tr>
        <td>
          {!editMode ? (
            invoice.SenderName
          ) : (
            <input
              type={'text'}
              value={newInvoice.SenderName}
              onChange={e => onChange('SenderName', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.SenderSurname
          ) : (
            <input
              type={'text'}
              value={newInvoice.SenderSurname}
              onChange={e => onChange('SenderSurname', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.SenderAddress
          ) : (
            <input
              type={'text'}
              value={newInvoice.SenderAddress}
              onChange={e => onChange('SenderAddress', e.target.value)}
            />
          )}
        </td>
        <td colSpan={2}>
          {!editMode ? (
            invoice.SenderIban
          ) : (
            <input
              type={'text'}
              value={newInvoice.SenderIban}
              onChange={e => onChange('SenderIban', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.SenderCall
          ) : (
            <input
              type={'text'}
              value={newInvoice.SenderCall}
              onChange={e => onChange('SenderCall', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.SenderModel
          ) : (
            <input
              type={'text'}
              value={newInvoice.SenderModel}
              onChange={e => onChange('SenderModel', e.target.value)}
            />
          )}
        </td>
      </tr>
      <tr>
        <th colSpan={7}>Sender</th>
      </tr>
      <tr>
        <th>Name</th>
        <th>Surname</th>
        <th>Address</th>
        <th colSpan={2}>IBAN</th>
        <th>Call</th>
        <th>Model</th>
      </tr>
      <tr>
        <td>
          {!editMode ? (
            invoice.ReceiverName
          ) : (
            <input
              type={'text'}
              value={newInvoice.ReceiverName}
              onChange={e => onChange('ReceiverName', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.ReceiverSurname
          ) : (
            <input
              type={'text'}
              value={newInvoice.ReceiverSurname}
              onChange={e => onChange('ReceiverSurname', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.ReceiverAddress
          ) : (
            <input
              type={'text'}
              value={newInvoice.ReceiverAddress}
              onChange={e => onChange('ReceiverAddress', e.target.value)}
            />
          )}
        </td>
        <td colSpan={2}>
          {!editMode ? (
            invoice.ReceiverIban
          ) : (
            <input
              type={'text'}
              value={newInvoice.ReceiverIban}
              onChange={e => onChange('ReceiverIban', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.ReceiverCall
          ) : (
            <input
              type={'text'}
              value={newInvoice.ReceiverCall}
              onChange={e => onChange('ReceiverCall', e.target.value)}
            />
          )}
        </td>
        <td>
          {!editMode ? (
            invoice.ReceiverModel
          ) : (
            <input
              type={'text'}
              value={newInvoice.ReceiverModel}
              onChange={e => onChange('ReceiverModel', e.target.value)}
            />
          )}
        </td>
      </tr>
      <tr>
        <th colSpan={2}>Amount</th>
        <th colSpan={2}>Currency</th>
        <th colSpan={3}>Execution Date</th>
      </tr>
      <tr>
        <td colSpan={2}>
          {!editMode ? (
            invoice.Amount
          ) : (
            <input
              type={'text'}
              value={newInvoice.Amount}
              onChange={e => onChange('Amount', e.target.value)}
            />
          )}
        </td>
        <td colSpan={2}>{invoice.Currency}</td>
        <td colSpan={3}>{invoice.ExecutionDate}</td>
      </tr>
      <tr>
        <td colSpan={7} />
      </tr>
    </React.Fragment>
  );
};

export default Invoice;
