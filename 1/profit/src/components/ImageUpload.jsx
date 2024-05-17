import React from 'react';

function ImageUpload({ onImageUpload }) {
    const handleFileChange = (e) => {
        if (e.target.files && e.target.files[0]) {
            let reader = new FileReader();
            reader.onload = function(event) {
                onImageUpload(event.target.result); 
            };
            reader.readAsDataURL(e.target.files[0]);
        }
    };

    return (
        <div className="upload-container">
            <input type="file" onChange={handleFileChange} />
        </div>
    );
}

export default ImageUpload;