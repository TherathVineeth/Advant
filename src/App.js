import React, { useState } from 'react';

function App() {
  const [memberId, setMemberId] = useState('');
  const [memberData, setMemberData] = useState(null);
  const [pharmacyData, setPharmacyData] = useState(null);
  const [showConfirmation, setShowConfirmation] = useState(false);

  const handleMemberIdChange = (e) => {
    setMemberId(e.target.value);
  };

  const fetchMemberData = () => {
    // You should replace this URL with the actual URL of your DotNet Core API.
    const apiUrl = `https://localhost:7130/api/Product/2`;

    fetch(apiUrl)
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Member not found');
        }
      })
      .then((data) => setMemberData(data))
      .catch((error) => {
        console.error('Error fetching member data:', error);
        setMemberData(null);
        setPharmacyData(null);
      });

    // Fetch pharmacy data separately
    const pharmacyApiUrl = `https://localhost:7130/api/Product/2`;

    fetch(pharmacyApiUrl)
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Pharmacy data not found');
        }
      })
      .then((data) => setPharmacyData(data))
      .catch((error) => {
        console.error('Error fetching pharmacy data:', error);
        setPharmacyData(null);
      });
  };

  const handleDeleteClick = () => {
    setShowConfirmation(true);
  };

  const confirmDelete = () => {
    // Send a DELETE request to your API for the atomic deletion
    const deleteApiUrl = `https://your-api-url/delete/${memberId}`;

    fetch(deleteApiUrl, { method: 'DELETE' })
      .then((response) => {
        if (response.ok) {
          // Deletion successful, reset state and display a message
          setMemberData(null);
          setPharmacyData(null);
          setMemberId('');
          setShowConfirmation(false);
        } else {
          throw new Error('Deletion failed');
        }
      })
      .catch((error) => {
        console.error('Error deleting data:', error);
        setShowConfirmation(false);
      });
  };

  const cancelDelete = () => {
    setShowConfirmation(false);
  };

  return (
    <div>
      <h1>ABC Insurance Company</h1>
      <label>
        Member ID:
        <input type="text" value={memberId} onChange={handleMemberIdChange} />
      </label>
      <button onClick={fetchMemberData}>Show</button>

      {memberData && (
        <div>
          <h2>Member Details</h2>
          <p>Name: {memberData.name}</p>
          <p>DOB: {memberData.dob}</p>
          {/* Display other member details here */}
          <button onClick={handleDeleteClick}>Delete Member</button>
        </div>
      )}

      {pharmacyData && (
        <div>
          <h2>Pharmacy Details</h2>
          <p>Prescription: {pharmacyData.prescription}</p>
          {/* Display other pharmacy details here */}
        </div>
      )}

      {showConfirmation && (
        <div>
          <p>Are you sure you want to delete this member and related pharmacy records?</p>
          <button onClick={confirmDelete}>Confirm</button>
          <button onClick={cancelDelete}>Cancel</button>
        </div>
      )}
    </div>
  );
}

export default App;
