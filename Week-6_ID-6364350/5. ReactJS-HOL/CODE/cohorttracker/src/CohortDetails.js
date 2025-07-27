
import React from 'react';
import styles from './CohortDetails.module.css';

const CohortDetails = ({ cohort }) => {
  // Define inline style for h3 based on currentStatus
  const headerStyle = {
    color: cohort.currentStatus === 'Ongoing' ? 'green' : 'blue'
  };

  return (
    <div className={styles.box}>
      <h3 style={headerStyle}>{cohort.technology}</h3>
      <dl>
        <dt>Start Date:</dt>
        <dd>{cohort.startDate}</dd>
        
        <dt>End Date:</dt>
        <dd>To Be Determined</dd>
        
        <dt>Status:</dt>
        <dd>{cohort.currentStatus}</dd>
        
        <dt>Participants:</dt>
        <dd>25</dd>
      </dl>
    </div>
  );
};

export default CohortDetails;

