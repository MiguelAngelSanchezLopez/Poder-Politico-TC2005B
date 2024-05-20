# Poder-Politico-TC2005B
Proyecto para el bloque de construcción de software y toma de decisiones


To start the project in VSCode terminal: 
<br />
Remember to be in the **poder-politico-ui** folder!! <br /> <br />
Enter terminal in vscode : ```Ctrl + Left Shift + ` ``` <br /> <br />
Access the right folder : ``` cd poder-politico-ui``` <br /> <br />
Start batch job : ``` npm start ``` , and wait for the webpage render in your browser. 
<br /><br />
If there's a react-scripts start problem try:
``` npm install react-scripts --save ```
<br /><br />
If there's missing dependencies like React Router:
``` npm i -D react-router-dom ```
<br /><br />
In case of probems with Typescript, follow steps: </br>
1. Make sure you have the latest versions:
   ``` npm install typescript@latest @types/react@latest @types/react-dom@latest --save-dev ```
2. Update the *tsconfig.json*, it should contain:
  ```
 {
  "compilerOptions": {
    "target": "es5",
    "lib": ["dom", "dom.iterable", "esnext"],
    "allowJs": true,
    "skipLibCheck": true,
    "esModuleInterop": true,
    "allowSyntheticDefaultImports": true,
    "strict": true,
    "forceConsistentCasingInFileNames": true,
    "noFallthroughCasesInSwitch": true,
    "module": "esnext",
    "moduleResolution": "node",
    "resolveJsonModule": true,
    "isolatedModules": true,
    "jsx": "react"
  },
  "include": ["src"]
}
```
3. Checkyour *package.json*, it should contain at least:
  ```
{
  "dependencies": {
    "react": "^17.0.2",
    "react-dom": "^17.0.2",
    "react-router-dom": "^5.2.0"
  },
  "devDependencies": {
    "typescript": "^4.2.3",
    "@types/react": "^17.0.2",
    "@types/react-dom": "^17.0.2",
    "@types/react-router-dom": "^5.1.7"
  }
}
```
4. And restart your server
   ```npm start```
</br></br> 
To terminate batch job in terminal press ``` Ctrl + C ```
