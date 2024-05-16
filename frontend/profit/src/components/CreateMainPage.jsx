import React, { useState } from "react";
import "./CreateMainPage.css";
import ImageUpload from "./ImageUpload";
import { Textarea } from "@chakra-ui/react";
import { Button, ButtonGroup } from '@chakra-ui/react';

export default function CreateMainPage() {
    const [image, setImage] = useState(null); 

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log("Заметка:", image); 
    };

    return (
        <>
            <form onSubmit={handleSubmit} className="post-upload">
                <h2>Сделать пост</h2>
                <ImageUpload onImageUpload={(img) => setImage(img)} /> 
                <Textarea placeholder="Введите текст поста" />
                <Button colorScheme='orange' type="submit">Опубликовать</Button>
            </form>
            <div class="post-container">
             <ul>
                    <li>
                        <p>Nickname</p>
                        <p>Картинка</p>
                        <i>Текст поста</i>
                        <div class="comments-container">
                            <p>Текст комментария</p>
                            <div class="create-comment-container">
                                <Textarea placeholder="Введите комментарий" />
                                <Button colorScheme='orange' type="submit">Отправить комментарий</Button>
                            </div>
                        </div>
                    </li>
                    
                    <li>
                        <p>123</p>
                        <img src="https://wallpaper.forfun.com/fetch/ad/ad6c8caee57e02a880b974f5bdf070a5.jpeg" />
                        <i>ну чисто я</i>
                        <div class="comments-container">
                            <p>Текст комментария</p>
                            <div class="create-comment-container">
                                <Textarea placeholder="Введите комментарий" />
                                <Button colorScheme='orange' type="submit">Отправить комментарий</Button>
                            </div>
                        </div>
                    </li>
                    <li>
                        <p>Momonga</p>
                        <img src="https://avatars.mds.yandex.net/get-altay/8074519/2a0000018930b0cf6e8007dcaaad52a05e13/L_height"/>
                        <i>My collection</i>
                        <div class="comments-container">
                            <p>Текст комментария</p>
                            <div class="create-comment-container">
                                <Textarea placeholder="Введите комментарий" />
                                <Button colorScheme='orange' type="submit">Отправить комментарий</Button>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </>
    );
}