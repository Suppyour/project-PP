import React, { useState } from 'react';
import axios from 'axios';
import "./CommentForm.css";

const CommentForm = ({ onCommentSubmit, onAddComment }) => {
    const [commentText, setCommentText] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.post('http://localhost:7177/Test2', { text: commentText });
            setCommentText('');
            if (onCommentSubmit) {
                onCommentSubmit();
            }
            if (onAddComment) {
                onAddComment(response.data); // Предполагается, что сервер возвращает созданный комментарий
            }
        } catch (error) {
            console.error("Ошибка при отправке комментария:", error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <textarea
                class='text-area'
                value={commentText}
                onChange={(e) => setCommentText(e.target.value)}
                placeholder="Введите комментарий"
            />
            <button class="post-comment" type="submit">Отправить комментарий</button>
        </form>
    );
};

export default CommentForm;
